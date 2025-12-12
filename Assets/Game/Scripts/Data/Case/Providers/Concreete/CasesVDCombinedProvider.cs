using Cysharp.Threading.Tasks;
using Game.Data.Case.Visual;
using System.Collections.Generic;
using System.Linq;

namespace Game.Data.Case.Providers.Concreete
{
    public class CasesVDCombinedProvider : ICasesVDProvider
    {
        private IEnumerable<ICasesVDProvider> _datasets;

        public CasesVDCombinedProvider(IEnumerable<ICasesVDProvider> datasets)
        {            
            _datasets = datasets;
        }

        public async UniTask<IEnumerable<CaseVD>> GetDatasAsync()
        {
            var datasets = _datasets;
            var allData = (await UniTask.WhenAll(datasets.Select(d => d.GetDatasAsync())))
                .SelectMany(x => x);
            return allData;
        }
    }
}