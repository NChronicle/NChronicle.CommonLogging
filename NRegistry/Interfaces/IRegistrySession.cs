using NPanda.NRegistry.Delegates;

namespace NPanda.NRegistry.Interfaces {

    public interface IRegistrySession {

        RegistrySession Configure (ConfigurationDelegate config);

        T Get <T> () where T : class;

        void Insert <T> () where T : class;

        void Upsert <T> () where T : class;

        void Update <T> () where T : class;

        void Delete <T> () where T : class;

        void RollBack ();

        IRegistrySession CreateSession ();

    }

}