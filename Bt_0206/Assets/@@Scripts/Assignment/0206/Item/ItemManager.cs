using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;
    public static ItemManager Instance { get { return _instance; } }


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void InitItemDictsFromLocal()
    {

    }

    public Dictionary<int, Item> ItemDicts = new Dictionary<int, Item>();
}
