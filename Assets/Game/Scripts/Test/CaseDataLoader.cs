using Game.Data.Case;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CaseDataLoader : MonoBehaviour
{
    [SerializeField]
    private string key;
    async void Start()
    {
        await Addressables.InitializeAsync().Task;
        var caseRegistrySo = await Addressables.LoadAssetAsync<CasesVisualDataRegistry>(key).Task;
        foreach (var caseSo in caseRegistrySo.Datas)
        {
            Debug.Log(caseSo.Name);
            Debug.Log(caseSo.Icon.name);
        }
    }
}
