using System;
using NPanda.NRegistry.Brokers;
using NPanda.NRegistry.Delegates;
using NPanda.NRegistry.Interfaces;

namespace NPanda.NRegistry {

    public class RegistrySession : IRegistrySession {

        private readonly ProxyBroker _proxyBroker;
        internal IConfiguration Configuration;

        public RegistrySession () {
            this.Configuration = NRegistry.Configuration.Clone();
            this._proxyBroker = new ProxyBroker();
        }

        public RegistrySession (IConfiguration configuration) {
            this.Configuration = configuration;
            this._proxyBroker = new ProxyBroker();
        }

        public RegistrySession Configure (ConfigurationDelegate config) {
            config(this.Configuration);
            return this;
        }

        public T Get <T> () where T : class {
            return this._proxyBroker.Resolve <T>();
        }

        public void Insert <T> () where T : class {
            throw new NotImplementedException();
        }

        public void Upsert <T> () where T : class {
            throw new NotImplementedException();
        }

        public void Update <T> () where T : class {
            throw new NotImplementedException();
        }

        public void Delete <T> () where T : class {
            throw new NotImplementedException();
        }

        public void RollBack () {
            throw new NotImplementedException();
        }

        public IRegistrySession CreateSession () {
            return new RegistrySession(this.Configuration.Clone());
        }

    }

}