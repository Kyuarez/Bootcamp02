using UnityEngine;

/// <summary>
/// ���� ���� ���� �� �Ѱ� �Ŵ���
/// </summary>
public class Operator : MonoBehaviour
{
    private LocalDataManager localDataManager;
    private ItemManager itemManager;

    private void Awake()
    {
        localDataManager = GetComponentInChildren<LocalDataManager>();
        itemManager = GetComponentInChildren<ItemManager>();
    }

    private void Start()
    {
        localDataManager.LoadItemListFromLocalData();
        itemManager.InitItemDictsFromLocal();
    }
}
