using System.Collections.Generic;
using UnityEngine;

public class LocalDataManager : MonoBehaviour
{
    #region Temp(Item)
    public void LoadItemListFromLocalData()
    {

    }

    //02.06 @TK : 플레이어 같은거 안만들어서 임시로 담을 아이템 로컬 데이터
    List<Item> localItemList = new List<Item>();

    private readonly string LOCAL_ITEMS = "LocalData/ItemData";
    #endregion
    
    
}
