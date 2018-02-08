using NPanda.NRegistry.Attributes;
using NPanda.NRegistry.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPanda.NRegistry.Tests.Get.Substitutes {

    [TestClass]
    public class TestBase : Tests.TestBase {

        [Key ("HKEY_CURRENT_USER\\Software\\NRegistry\\TestClass")]
        public class TestClass {

            [Value]
            public virtual string MyString { get; set; }

            [Value (ValueKind.RegExpandSz)]
            public virtual string MyExpandString { get; set; }

        }

    }

}