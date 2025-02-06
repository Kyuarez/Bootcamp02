using System;
using UnityEngine;

//�ΰ��ӿ����� ������ ����
public class Item : MonoBehaviour
{
    public ItemData ItemData;
    public Sprite ItemIcon;

    public void InitItemData(ItemData itemData)
    {
        
    }
}

//Default ������ ����
[Serializable]
public class ItemData
{
    private string Name;
    private string Description;
    private int Damage;
    private int Armor;
    private int EnchantCount;
}
