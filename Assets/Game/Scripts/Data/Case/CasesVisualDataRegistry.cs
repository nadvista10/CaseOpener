using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Case
{
    [CreateAssetMenu(fileName = "CasesVisualDataRegistry", menuName = "Cases/CasesVisualDataRegistry")]
    public class CasesVisualDataRegistry : ScriptableObject
    {
        [field: SerializeField]
        public List<CaseVisualData> Datas { get; private set; }
    }
}