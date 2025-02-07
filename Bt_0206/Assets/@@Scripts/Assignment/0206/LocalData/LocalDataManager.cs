using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalDataManager : MonoBehaviour
{
    private static LocalDataManager _instance;
    public static LocalDataManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

    #region Temp(Item)
    public void LoadItemListFromLocalData()
    {
        
    }

    public void WriteItemListFromLocalData() 
    {
           
    }

    //02.06 @TK : 플레이어 같은거 안만들어서 임시로 담을 아이템 로컬 데이터
    List<Item> localItemList = new List<Item>();

    private string LOCAL_ITEMS = Application.streamingAssetsPath + "/LocalData/ItemData.json";
    #endregion
    
    
}
