using UnityEngine;

namespace Game.Data.Case.Visual
{
    [CreateAssetMenu(fileName = "CaseVisualData", menuName = "Cases/CaseVisualData")]
    public class CaseVD : ScriptableObject
    {
        [field: SerializeField]
        public TextAsset Name { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}