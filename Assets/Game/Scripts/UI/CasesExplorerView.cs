using Cysharp.Threading.Tasks;
using Game.Data.Case.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Game.UI.CasesExplorer
{
    public class CasesExplorerView : MonoBehaviour
    {
        [SerializeField]
        private Transform contentRoot;

        [SerializeField]
        private CaseCardView previewCard;

        private List<CaseCardView> _allObjects = new();

        private ICasesVDProvider _provider;

        [Inject(Id = "combined")]
        private void Construct(ICasesVDProvider provider)
        {
            _provider = provider;
        }

        private async UniTask Start()
        {
            CollectChildrenViews();
            await GenerateCards();
        }

        private void CollectChildrenViews()
        {
            _allObjects.AddRange(contentRoot.GetComponentsInChildren<CaseCardView>());
        }
        private async UniTask GenerateCards()
        {
            var datas = (await _provider.GetDatasAsync()).ToArray();

            for (int i = _allObjects.Count; i < datas.Length; i++)
            {
                var card = Instantiate(previewCard, contentRoot);
                _allObjects.Add(card);
            }

            for(int i = 0; i < datas.Length; i++)
            {
                var caseView = _allObjects[i];
                var data = datas[i];

                caseView.gameObject.SetActive(true);
                caseView.Setup(data);
            }
            for(int i = datas.Length; i < _allObjects.Count;i++)
            {
                var caseView = _allObjects[i];

                caseView.gameObject.SetActive(false);
            }
        }
    }
}