using System;
using UnityEngine;

namespace Bootcamp0213
{
    public class ItemSample : MonoBehaviour
    {
        public ItemSO item;

        private void Awake()
        {
            item = Resources.Load<Bootcamp0213.ItemSO>("Sample/SO/Item_0");
        }

        private void Update()
        {
            if(true == Input.GetKeyDown(KeyCode.Space))
            {
                ItemInfo();
            }
            
        }

        private void ItemInfo()
        {
            Debug.Log(item.ID);
            Debug.Log(item.CodeName);
            Debug.Log(item.Description);
            Debug.Log(item.Price);
        }
    }

}
