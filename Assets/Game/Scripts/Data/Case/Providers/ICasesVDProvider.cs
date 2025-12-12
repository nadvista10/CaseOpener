using Cysharp.Threading.Tasks;
using Game.Data.Case.Visual;
using System.Collections.Generic;

namespace Game.Data.Case.Providers
{
    public interface ICasesVDProvider
    {
        public UniTask<IEnumerable<CaseVD>> GetDatasAsync();
    }
}