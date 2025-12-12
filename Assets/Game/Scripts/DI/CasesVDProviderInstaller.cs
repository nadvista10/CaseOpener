using Game.Data.Case.Providers;
using Game.Data.Case.Providers.Concreete;
using Game.Data.Case.Visual;
using UnityEngine;
using Zenject;

namespace Game.Di
{
    public class CasesVDProviderInstaller : MonoInstaller
    {
        [SerializeField]
        private string addressableKey;

        [SerializeField]
        private CasesVDRegistrySO localCases;

        public override void InstallBindings()
        {
            Container.Bind<ICasesVDProvider>().WithId("local")
               .To<CasesVDLocalProvider>()
               .FromNew()
               .WithArguments(localCases);

            Container.Bind<ICasesVDProvider>().WithId("addressable")
                .To<CasesVDAddressableProvider>()
                .FromNew()
                .WithArguments(addressableKey);

            Container.Bind<ICasesVDProvider>().WithId("combined")
                .To<CasesVDCombinedProvider>()
                .AsSingle();
        }
    }
}