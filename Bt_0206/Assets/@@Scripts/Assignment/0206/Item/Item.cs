using System;
using UnityEngine;

//인게임에서의 아이템 상태
public class Item : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int armor;

    private ItemData itemData;

    public string Name { get { return itemData.Name; } }
    public string Description { get { return itemData.Description; } }
    public int Damage { get { return damage; } }
    public int Armor { get { return armor; } } 
    
    public void InitItemData(ItemData data)
    {
        itemData = data;
        damage = data.BaseDamage;
        armor = data.BaseArmor;
    }
}

//Default 아이템 상태
[Serializable]
public class ItemData
{
    private string name;
    private string description;
    private int baseDamage;
    private int baseArmor;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int BaseDamage { get { return baseDamage; } }
    public int BaseArmor { get { return baseArmor; } }

    //뭔가 데이터로 받으면 파라미터 넣어서 해결하자.
    public ItemData()
    {

    }
}
