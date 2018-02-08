using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using NPanda.NRegistry.Interfaces;

namespace NPanda.NRegistry.Brokers {

    internal class DynamicTypeBroker : IDynamicTypeBroker {

        public AssemblyBuilder AssemblyBuilder => _AssemblyBuilder.AssemblyBuilder;

        public ModuleBuilder ModuleBuilder => _ModuleBuilder.ModuleBuilder;

        public Type BuildTypeFromInterface <T> () where T : class {
            var typeName = this.CreateTypeName(typeof (T).Name);
            var typeBuilder = this.CreateType(typeName);
            typeBuilder.AddInterfaceImplementation(typeof (T));
            AddMethods(typeBuilder, typeof (T).GetMethods());
            return typeBuilder.CreateType();
        }

        private static void AddMethods (TypeBuilder typeBuilder, MethodInfo[] methodInfos) {
            foreach (var methodInfo in methodInfos) {
                var methodAttributes = methodInfo.Attributes ^ MethodAttributes.Abstract;
                var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
                var methodBuilder = typeBuilder.DefineMethod(methodInfo.Name, methodAttributes, methodInfo.ReturnType, parameterTypes);
                SetMethodBody(methodBuilder, methodInfo);
                if (!methodInfo.IsGenericMethod) continue;
                SetGenerics(methodBuilder, methodInfo);
            }
        }

        private static void SetMethodBody (MethodBuilder methodBuilder, MethodInfo methodInfo) {
            var ilGen = methodBuilder.GetILGenerator();
            if (methodInfo.ReturnType != typeof (void)) {
                if (methodInfo.ReturnType.IsGenericParameter) {
                    if (methodInfo.ReturnType.GenericParameterAttributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint))
                        ilGen.Emit(OpCodes.Ldnull);
                    else { // Could be a value type or reference type
                        ilGen.DeclareLocal(typeof (Type));
                        var referenceTypeMarker = ilGen.DefineLabel();
                        ilGen.Emit(OpCodes.Ldtoken, methodInfo.ReturnType);
                        ilGen.Emit(OpCodes.Call, typeof (Type).GetMethod("GetTypeFromHandle", new[] {typeof (RuntimeTypeHandle)}));
                        ilGen.Emit(OpCodes.Stloc_0);
                        ilGen.Emit(OpCodes.Ldloc_0);
                        ilGen.EmitCall(OpCodes.Callvirt, typeof(Type).GetProperty("IsValueType").GetMethod, new Type[0]);
                        ilGen.Emit(OpCodes.Brfalse_S, referenceTypeMarker);
                        ilGen.Emit(OpCodes.Ldloc_0);
                        ilGen.Emit(OpCodes.Call, typeof (Activator).GetMethod("CreateInstance", new[] {typeof (Type)}));
                        ilGen.Emit(OpCodes.Unbox_Any, methodInfo.ReturnType);
                        ilGen.Emit(OpCodes.Ret);
                        ilGen.MarkLabel(referenceTypeMarker);
                        ilGen.Emit(OpCodes.Ldnull);
                    }
                }
                else if (methodInfo.ReturnType.IsValueType) {
                    ilGen.Emit(OpCodes.Ldtoken, methodInfo.ReturnType);
                    ilGen.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle", new [] { typeof(RuntimeTypeHandle) }));
                    ilGen.Emit(OpCodes.Call, typeof (Activator).GetMethod("CreateInstance", new[] { typeof (Type) }));
                    ilGen.Emit(OpCodes.Unbox_Any, methodInfo.ReturnType);
                }
                else ilGen.Emit(OpCodes.Ldnull);
            }
            ilGen.Emit(OpCodes.Ret);
        }

        private static void SetGenerics (MethodBuilder methodBuilder, MethodInfo methodInfo) {
            var genericArgs = methodInfo.GetGenericMethodDefinition().GetGenericArguments();
            if (!genericArgs.Any()) return;
            var genericParams = methodBuilder.DefineGenericParameters(methodInfo.GetGenericArguments().Select(p => p.Name).ToArray());
            for (var i = 0; i < genericParams.Length; i++) {
                genericParams[i].SetGenericParameterAttributes(genericArgs[i].GenericParameterAttributes);
                genericParams[i].SetInterfaceConstraints(genericArgs[i].GetGenericParameterConstraints().Where(t => t.IsInterface).ToArray());
                var parameter = genericArgs[i].GetGenericParameterConstraints().FirstOrDefault(t => !t.IsInterface);
                if (parameter != null) genericParams[i].SetBaseTypeConstraint(parameter);
            }
        }

        private TypeBuilder CreateType (string typeName) {
            var typeBuilder = this.ModuleBuilder.DefineType($"EenixRAL.Dynamic.{typeName}", TypeAttributes.Public);
            var ctor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new Type[] {});
            ctor.GetILGenerator().Emit(OpCodes.Ret);
            return typeBuilder;
        }

        private string CreateTypeName (string interfaceName) {
            var token = Guid.NewGuid().ToString().Substring(0, 6);
            if (interfaceName.StartsWith("I")
                && char.IsUpper(interfaceName[1])) return interfaceName.Substring(1) + token;
            return interfaceName + token;
        }

        private static class _AssemblyBuilder {

            public static readonly AssemblyName AssemblyName;
            public static readonly AssemblyBuilder AssemblyBuilder;

            static _AssemblyBuilder () {
                AssemblyName = new AssemblyName("EenixRAL.Dynamic");
                AssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.Run);
            }

        }

        private static class _ModuleBuilder {

            public static readonly ModuleBuilder ModuleBuilder;

            static _ModuleBuilder () {
                var assemblyName = _AssemblyBuilder.AssemblyName.Name;
                ModuleBuilder = _AssemblyBuilder.AssemblyBuilder.DefineDynamicModule(assemblyName);
            }

        }

    }

}