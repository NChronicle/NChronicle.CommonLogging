using NPanda.NRegistry.Attributes;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Win32;

namespace NPanda.NRegistry.Models {

    internal class RegistrySetEvent : RegistryEvent {

        private readonly IMethodInvocation _input;

        public RegistrySetEvent (IMethodInvocation input, KeyAttribute key, ValueAttribute value) {
            this._input = input;
            this.TargetKey = key.KeyPath;
            this.TargetValueName = value.ValueName;
            this.TargetValueKind = value.ValueKind;
        }

        // todo Refactor so RegistryEvents are agnostic of IMethodReturn and IMethodInvocation
        public override IMethodReturn Execute () {
            using (var key = this.GetKeyFromPath(this.TargetKey, true, true)) {
                if (null != key) key.SetValue(this.TargetValueName, this._input.Inputs[0], (RegistryValueKind) this.TargetValueKind);
            }
            return this.ReturnValue(this._input, this._input.Inputs[0]);
        }

        public override void Undo() { }

    }

}