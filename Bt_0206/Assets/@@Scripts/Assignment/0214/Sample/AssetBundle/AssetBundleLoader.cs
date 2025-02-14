using System.IO;
using System.Collections;
using UnityEngine;

//로드는 거의 코루틴이라고 생각해도 된다.
public class AssetBundleLoader : MonoBehaviour
{
    string path = "./AssetBundle/sampleasset001";

    private void Start()
    {
        OnLoadAssetBundle();
    }

    public void OnLoadAssetBundle()
    {
        StartCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return request;
        AssetBundle bundle = request.assetBundle;

        GameObject prefab = bundle.LoadAsset<GameObject>("RedSquare");
        Instantiate(prefab);

    }
}
