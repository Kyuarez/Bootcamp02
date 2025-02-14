using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SampleAddressableLoader : MonoBehaviour
{
    //AssetReference : 특정 타입 지정 않하고 어드레서블 리소스 참조
    //근데 뒤에 뭐 붙이면, 그 붙인 타입으로 참조
    public AssetReferenceGameObject capsule_addr;
    //public AssetReferenceT<GameObject> capsule_addr2; //이렇게 선언해도 동일함.

    public GameObject go = new GameObject();

    private void Start()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync();
        yield return init;
    }

    public void OnCreateButtonEnter()
    {
        capsule_addr.InstantiateAsync().Completed += (obj) =>
        {
            go = obj.Result;

        };
    }

    public void OnReleaseButtonEnter()
    {
        Addressables.ReleaseInstance(go);
    }
}
