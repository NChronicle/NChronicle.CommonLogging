using System;
using System.Reflection.Emit;

namespace NPanda.NRegistry.Interfaces {

    internal interface IDynamicTypeBroker {

        AssemblyBuilder AssemblyBuilder { get; }
        ModuleBuilder ModuleBuilder { get; }

        Type BuildTypeFromInterface <T> () where T : class;

    }

}