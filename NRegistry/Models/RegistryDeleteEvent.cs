using NPanda.NRegistry.Attributes;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace NPanda.NRegistry.Models {

    internal class RegistryDeleteEvent : RegistryEvent {

        private readonly IMethodInvocation _input;

        public RegistryDeleteEvent (IMethodInvocation input, KeyAttribute key, ValueAttribute value) {
            this._input = input;
            this.TargetKey = key.KeyPath;
            this.TargetValueName = value.ValueName;
        }

        public override IMethodReturn Execute () {
            using (var key = this.GetKeyFromPath(this.TargetKey)) {
                key.DeleteValue(this.TargetValueName);
            }
            return this.ReturnValue(this._input, null);
        }

        public override void Undo() { }

    }

}