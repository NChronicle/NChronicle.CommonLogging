using System;
using System.Collections.Generic;
using NPanda.NRegistry.Models;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace NPanda.NRegistry.Brokers {

    public class InterceptionBroker : IInterceptionBehavior {

        public IEnumerable <Type> GetRequiredInterfaces () {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke (IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext) {
            var @event = RegistryEvent.Create(input);
            if (@event == null) return getNext()(input, getNext);
            return @event.Execute();
        }

        public bool WillExecute => true;

    }

}