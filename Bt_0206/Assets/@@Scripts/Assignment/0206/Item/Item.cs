using System;
using UnityEngine;

//인게임에서의 아이템 상태
public class Item : MonoBehaviour
{
    public ItemData ItemData;
    public Sprite ItemIcon;

    public void InitItemData(ItemData itemData)
    {
        
    }

    //등급 별 수치들 Init 할 때 계산
}

//Default 아이템 상태
[Serializable]
public class ItemData
{
    private string Name;
    private string Description;
    private int Damage;
    private int Armor;
    private int EnchantCount;
}
