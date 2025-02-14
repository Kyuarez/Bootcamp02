using System.IO;
using System.Collections;
using UnityEngine;

//�ε�� ���� �ڷ�ƾ�̶�� �����ص� �ȴ�.
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
