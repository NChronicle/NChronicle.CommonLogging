namespace NPanda.NRegistry.Interfaces {

    internal interface IProxyBroker {

        T Resolve<T>() where T : class;

    }

}