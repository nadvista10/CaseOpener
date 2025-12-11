using UnityEngine;

namespace Game.Case
{

    [CreateAssetMenu(fileName = "CaseDataSo", menuName = "Cases/CaseDataSo")]
    public class CaseDataSo : ScriptableObject
    {
        [field: SerializeField]
        public TextAsset DataJson;

        [field: SerializeField]
        public Sprite Icon;
    }
}