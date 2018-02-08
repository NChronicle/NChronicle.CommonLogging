using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class SealedClassException : Exception {

        public SealedClassException (Type type) : base(string.Format(ExceptionStrings.SealedClass, type.Name)) {}

        public SealedClassException (string message) : base(message) {}

    }

}