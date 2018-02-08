using NPanda.NRegistry.Attributes;
using Microsoft.Practices.Unity.InterceptionExtension;
using NPanda.NRegistry.Exceptions;

namespace NPanda.NRegistry.Models {

    internal class RegistryReadEvent : RegistryEvent {

        private readonly IMethodInvocation _input;

        public RegistryReadEvent (IMethodInvocation input, KeyAttribute key, ValueAttribute value) {
            this._input = input;
            this.TargetKey = key.KeyPath;
            this.TargetValueName = value.ValueName;
        }

        public override IMethodReturn Execute () {
            using (var key = this.GetKeyFromPath(this.TargetKey)) {
                if (null == key) throw new AbsentKeyException(this.TargetKey, this.TargetValueName);
                return this.ReturnValue(this._input, key.GetValue(this.TargetValueName));
            }
        }

        public override void Undo () { }

    }

}