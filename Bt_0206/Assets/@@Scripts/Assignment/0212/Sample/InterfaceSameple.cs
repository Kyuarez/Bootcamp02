using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace Bootcamp0212
{
    public interface ICountAble
    {
        public int Count { get; set; }

        void CountPlus();
    
    }

    public interface IUseAble
    {
        void Use();
    }

    public class Item
    {

    }

    public class Potion : Item, ICountAble, IUseAble
    {
        private int count;
        public int Count
        {
            get // get : Potion.CountMethod(); = Potion.Count;
            {
                return count;
            }
            set //set
            {
                count = Mathf.Clamp(value, 0, 100);
            }
        }

        public int CountMethod()
        {
            return count;
        }

        public void SetCount(int value)
        {
            count = value;
        }

        public void CountPlus()
        {
            if (Count >= 100)
            {
                return;
            }
            Count++;
        }

        public void Use()
        {
            if(Count <= 0)
            {
                return;
            }

            Count--;
        }
    }


    public class InterfaceSameple : MonoBehaviour
    {

        void Start()
        {
            Potion potion = new Potion();
            potion.Count = 99;

        }

        void Update()
        {
            
        }
    }

}

