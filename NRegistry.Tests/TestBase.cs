namespace NPanda.NRegistry.Tests {

    public abstract class TestBase {

        protected RegistrySession Session;

        protected TestBase () {
            this.Session = NRegistry.GetContainer();
        }

    }

}