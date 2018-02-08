using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class InaccessibleTypeException : Exception {

        public InaccessibleTypeException(Type type) : base(string.Format(ExceptionStrings.InaccessibleType, type.Name)) { }

        public InaccessibleTypeException(string message) : base(message) {}

    }

}