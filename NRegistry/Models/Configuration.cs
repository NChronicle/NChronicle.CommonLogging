using NPanda.NRegistry.Interfaces;

namespace NPanda.NRegistry.Models {

    public class Configuration : IConfiguration {

        public IConfiguration Clone () {
            return this.MemberwiseClone() as IConfiguration;
        }

    }

}