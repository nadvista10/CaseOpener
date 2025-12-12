using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Case.Visual
{
    [CreateAssetMenu(fileName = "CasesVisualDataRegistry", menuName = "Cases/CasesVisualDataRegistry")]
    public class CasesVDRegistrySO : ScriptableObject
    {
        [field: SerializeField]
        public List<CaseVD> Datas { get; private set; }
    }
}