using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class AbsentKeyException : Exception {

        public AbsentKeyException(string targetKey, string targetValueName) : base(string.Format(ExceptionStrings.AbsentKey, targetValueName, targetKey)) { }

        public AbsentKeyException(string message) : base(message) {}

    }

}