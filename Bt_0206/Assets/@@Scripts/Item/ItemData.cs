using UnityEngine;

namespace Bootcamp0206
{
    public class ItemData
    {
        public string ItemName;
        [TextArea] public string ItmeDescription;

        public ItemData(string itemName, string itmeDescription)
        {
            ItemName = itemName;
            ItmeDescription = itmeDescription;
        }
    }
}


