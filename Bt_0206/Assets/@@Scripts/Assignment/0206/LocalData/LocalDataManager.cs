using System.Collections.Generic;
using UnityEngine;

public class LocalDataManager : MonoBehaviour
{
    #region Temp(Item)
    public void LoadItemListFromLocalData()
    {

    }

    //02.06 @TK : �÷��̾� ������ �ȸ��� �ӽ÷� ���� ������ ���� ������
    List<Item> localItemList = new List<Item>();

    private readonly string LOCAL_ITEMS = "LocalData/ItemData";
    #endregion
    
    
}
