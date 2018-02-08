using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NPanda.NRegistry.Attributes;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Win32;
using NPanda.NRegistry.Enumerations;
using System;

namespace NPanda.NRegistry.Models {

    internal abstract class RegistryEvent {

        private static readonly Dictionary <string, Func<RegistryKey>> HiveMap = new Dictionary <string, Func<RegistryKey>> {
            {"HKEY_LOCAL_MACHINE", () => Registry.LocalMachine},
            {"HKEY_CURRENT_USER", () => Registry.CurrentUser},
            {"HKEY_CLASSES_ROOT", () => Registry.ClassesRoot},
            {"HKEY_CURRENT_CONFIG", () => Registry.CurrentConfig},
            {"HKEY_USER", () => Registry.Users},
            {"HKEY_PERFORMANCE_DATA", () => Registry.PerformanceData}
        };

        public virtual string TargetKey { get; set; }
        public virtual string TargetValueName { get; set; }
        public virtual ValueKind TargetValueKind { get; set; }

        public static RegistryEvent Create (IMethodInvocation input) {
            var (matchedProperty, isSet) = FindInvokingProperty(input);
            if (null == matchedProperty) return null;
            var value = ValueAttribute.GetFromProperty(matchedProperty);
            if (null == value) return null;
            var key = input.Target.GetType().GetCustomAttribute <KeyAttribute>();
            if (isSet) {
                if (input.Inputs.Count == 0 || input.Inputs[0] == null) return new RegistryDeleteEvent(input, key, value);
                return new RegistrySetEvent(input, key, value);
            }
            return new RegistryReadEvent(input, key, value);
        }

        private static (PropertyInfo matchedProperty, bool isSet) FindInvokingProperty (IMethodInvocation input) {
            foreach (var property in input.Target.GetType().GetProperties()) {
                var isGet = property.GetMethod.Name == input.MethodBase.Name;
                var isSet = property.SetMethod.Name == input.MethodBase.Name;
                if (!isGet && !isSet) continue;
                return (property, isSet);
            }
            return (null, false);
        }

        protected RegistryKey GetKeyFromPath (string path, bool writable = false, bool create = false) {
            // todo: Defense
            var pathParts = path.Split('\\');
            var hivePart = pathParts[0].ToUpper();
            var hivePartIsValid = HiveMap.ContainsKey(hivePart);
            if (!hivePartIsValid) return null;
            RegistryKey currentKey, childKey, targetKey;
            currentKey = childKey = targetKey = null;
            try {
                currentKey = HiveMap[hivePart]();
                foreach (var pathPart in pathParts.Skip(1)) {
                    var isTarget = pathPart == pathParts.Last();
                    var openForWrite = (create && !isTarget) || (writable && isTarget);
                    childKey = currentKey.OpenSubKey(pathPart, openForWrite);
                    if (null == childKey) {
                        if (!create) break;
                        var keyPermission = openForWrite ? RegistryKeyPermissionCheck.ReadWriteSubTree : RegistryKeyPermissionCheck.ReadSubTree;
                        childKey = currentKey.CreateSubKey(pathPart, keyPermission);
                    }
                    if (isTarget) {
                        targetKey = childKey;
                        childKey = null;
                    }
                    currentKey.Dispose();
                    currentKey = childKey;
                }
            } finally {
                currentKey?.Dispose();
                childKey?.Dispose();
            }
            
            return targetKey;
        }

        protected IMethodReturn ReturnValue (IMethodInvocation input, object value) {
            var arguments = new object[input.Arguments.Count];
            for (var i = 0; i < input.Arguments.Count; i++) arguments[i] = input.Arguments[i];
            return new VirtualMethodReturn(input, value, arguments);
        }

        public abstract IMethodReturn Execute ();

        public abstract void Undo ();

    }

}