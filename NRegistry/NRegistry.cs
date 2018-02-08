using System;
using NPanda.NRegistry.Delegates;
using NPanda.NRegistry.Models;

namespace NPanda.NRegistry {

    public static class NRegistry {

        internal static Configuration Configuration;

        static NRegistry () {
            Configuration = new Configuration();
        }

        public static void Configure (ConfigurationDelegate config) {
            config(Configuration);
        }

        public static T Get <T> () where T : class {
            return new RegistrySession().Get<T>();
        }

        public static void Insert <T> () where T : class {
            throw new NotImplementedException();
        }

        public static void Upsert <T> () where T : class {
            throw new NotImplementedException();
        }

        public static void Update <T> () where T : class {
            throw new NotImplementedException();
        }

        public static void Delete <T> () where T : class {
            throw new NotImplementedException();
        }

        public static RegistrySession GetContainer () {
            return new RegistrySession(Configuration.Clone());
        }

    }

}