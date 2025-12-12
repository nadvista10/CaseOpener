using Cysharp.Threading.Tasks;
using Game.Data.Case.Visual;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Data.Case.Providers.Concreete
{
    [Serializable]
    public class CasesVDAddressableProvider : ICasesVDProvider
    {
        [SerializeField]
        private string providerAddressableKey;

        private CasesVDRegistrySO _registry;

        public CasesVDAddressableProvider(string addressableKey)
        {
            providerAddressableKey = addressableKey;
        }

        public async UniTask<IEnumerable<CaseVD>> GetDatasAsync()
        {
            if(_registry == null)
            {
                await Addressables.InitializeAsync().ToUniTask();
                _registry = await Addressables.LoadAssetAsync<CasesVDRegistrySO>(providerAddressableKey).ToUniTask();
            }

            return _registry.Datas;
        }
    }
}