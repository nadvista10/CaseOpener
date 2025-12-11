using Game.Data.Case;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

namespace Game.UI.CasesExplorer
{
    public class CasesExplorerView : MonoBehaviour
    {
        [SerializeField]
        private Transform contentRoot;

        [SerializeField]
        private CaseCardView previewCard;

        private List<CaseCardView> _allObjects = new();
        private List<CaseCardView> _workingObjects = new();

        private CasesVisualDataRegistry _registry;

        const string REGISTRY_KEY = "CasesVisualDataRegistry";

        private async void Start()
        {
            await Addressables.InitializeAsync().Task;

            _registry = await Addressables.LoadAssetAsync<CasesVisualDataRegistry>(REGISTRY_KEY).Task;

            CollectChildrenViews();
            GenerateCards();
        }

        private void CollectChildrenViews()
        {
            _allObjects.AddRange(contentRoot.GetComponentsInChildren<CaseCardView>());
        }
        private void GenerateCards()
        {
            if(_registry == null)
            {
                Debug.LogWarning("Registry is null");
                return;
            }

            for (int i = _allObjects.Count; i < _registry.Datas.Count; i++)
            {
                var card = Instantiate(previewCard, contentRoot);
                _allObjects.Add(card);
            }

            for(int i = 0; i < _registry.Datas.Count; i++)
            {
                var caseView = _allObjects[i];
                var data = _registry.Datas[i];

                caseView.gameObject.SetActive(true);
                caseView.Setup(data);
            }
            for(int i = _registry.Datas.Count; i < _allObjects.Count;i++)
            {
                var caseView = _allObjects[i];

                caseView.gameObject.SetActive(false);
            }
        }
    }
}