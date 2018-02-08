using System.Linq;
using System.Reflection;
using NPanda.NRegistry.Attributes;
using NPanda.NRegistry.Exceptions;
using NPanda.NRegistry.Interfaces;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace NPanda.NRegistry.Brokers {

    internal class ProxyBroker : IProxyBroker {

        private readonly DynamicTypeBroker _typeBuildBroker;

        public ProxyBroker () {
            this._typeBuildBroker = new DynamicTypeBroker();
        }

        public T Resolve <T> () where T : class {
            this.ValidateType <T>();
            var targetType = typeof (T).IsInterface ? this._typeBuildBroker.BuildTypeFromInterface <T>() : typeof (T);
            return (T) Intercept.NewInstance(targetType, new VirtualMethodInterceptor(), new[] {new InterceptionBroker()});
        }

        private void ValidateType <T> () {
            var targetType = typeof (T);
            if (targetType.GetCustomAttribute <KeyAttribute>() == null) throw new AbsentKeyAttributeException(targetType);
            if (targetType.IsSealed) throw new SealedClassException(targetType);
            if (!targetType.IsPublic && !targetType.IsNestedPublic) throw new InaccessibleTypeException(targetType);
            var valueProperties = targetType.GetProperties().Where(m => m.GetCustomAttribute <ValueAttribute>() != null);
            foreach (var valueProperty in valueProperties)
                if (!valueProperty.GetMethod.IsVirtual || !valueProperty.GetMethod.IsVirtual) throw new SealedValuePropertyException(targetType, valueProperty.Name);
            var valueMethods = targetType.GetMethods().Where(m => m.GetCustomAttribute <ValueAttribute>() != null);
            foreach (var valueMethod in valueMethods)
                if (!valueMethod.IsVirtual) throw new SealedValueMethodException(targetType, valueMethod.Name);
        }

    }

}