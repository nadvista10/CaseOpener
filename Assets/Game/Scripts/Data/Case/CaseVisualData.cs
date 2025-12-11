using NUnit.Framework;
using UnityEngine;

namespace Game.Data.Case
{

    [CreateAssetMenu(fileName = "CaseVisualData", menuName = "Cases/CaseVisualData")]
    public class CaseVisualData : ScriptableObject
    {
        [field: SerializeField]
        public TextAsset Name { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}