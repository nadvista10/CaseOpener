using Cysharp.Threading.Tasks;
using Game.Data.Case.Visual;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Case.Providers.Concreete
{
    [Serializable]
    public class CasesVDLocalProvider : ICasesVDProvider
    {
        [SerializeField]
        private CasesVDRegistrySO registry;

        public CasesVDLocalProvider(CasesVDRegistrySO registry)
        {
            this.registry = registry;
        }

        public UniTask<IEnumerable<CaseVD>> GetDatasAsync()
        {
            return UniTask.FromResult((IEnumerable<CaseVD>)registry.Datas);
        }
    }
}