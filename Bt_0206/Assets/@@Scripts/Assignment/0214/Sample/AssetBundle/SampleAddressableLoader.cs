using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SampleAddressableLoader : MonoBehaviour
{
    //AssetReference : Ư�� Ÿ�� ���� ���ϰ� ��巹���� ���ҽ� ����
    //�ٵ� �ڿ� �� ���̸�, �� ���� Ÿ������ ����
    public AssetReferenceGameObject capsule_addr;
    //public AssetReferenceT<GameObject> capsule_addr2; //�̷��� �����ص� ������.

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
