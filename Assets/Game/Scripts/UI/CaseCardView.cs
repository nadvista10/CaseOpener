using Game.Data.Case;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.CasesExplorer
{
    public class CaseCardView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI nameLabel;

        [SerializeField]
        private Image previewImage;

        public void Setup(CaseVisualData data) 
        { 
            nameLabel.text = data.Name.text;
            previewImage.sprite = data.Icon;
        }
    }
}