using UnityEngine;

namespace Bootcamp0213
{
    [CreateAssetMenu(menuName ="Bootcamp/Item", fileName ="Item_")]
    public class ItemSO : ScriptableObject
    {
        public GameObject ItemBody;

        [SerializeField] private int id;
        [SerializeField] private string codeName;
        [TextArea(1,3)] [SerializeField] private string description;
        [SerializeField] private int price;

        public int ID { get { return id; } }
        public string CodeName { get { return codeName; } }
        public string Description { get { return description; } }
        public int Price { get { return price; } }
    }

}
