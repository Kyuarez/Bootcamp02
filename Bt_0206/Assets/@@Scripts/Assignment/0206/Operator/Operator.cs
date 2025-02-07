using UnityEngine;

/// <summary>
/// 게임 실행 관리 및 총괄 매니저
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
