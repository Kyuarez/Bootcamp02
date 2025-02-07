using System.Collections.Generic;
using System;
using UnityEngine;

//�ΰ��ӿ����� ������ ����
public class Item : MonoBehaviour
{
    public ItemData ItemData;
    public Sprite ItemIcon;

    public Item()
    {
        ItemData = null;
        ItemIcon = null;
    }

    public Item(ItemData itemData)
    {

    }
}

//Default ������ ����
[Serializable]
public class ItemData
{
    public int TempID;
    public string Name;
    public string Description;
    public string IconPath;
    public int Damage;
    public int Armor;
    public int EnchantCount;
    public ItemGradeType ItemGradeType;
}

[Serializable]
public class ItemWrapper
{
    public List<ItemData> ItemData;
    
    public ItemWrapper(List<ItemData> _itemData)
    {
        ItemData = _itemData;
    }
}