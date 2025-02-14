using UnityEngine;

namespace Bootcamp0214
{
    public class Singleton : MonoBehaviour
    {
        private static Singleton _instance;
        public static Singleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public int point = 0;
        public void PointPlus()
        {
            point++;
        }
    }

}
