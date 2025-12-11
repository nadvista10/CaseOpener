using Game.Case;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CaseDataLoader : MonoBehaviour
{
    [SerializeField]
    private string key;
    async void Start()
    {
        await Addressables.InitializeAsync().Task;
        var caseSO = await Addressables.LoadAssetAsync<CaseDataSo>(key).Task;

        Debug.Log(caseSO.DataJson);
        Debug.Log(caseSO.Icon.name);
    }
}
