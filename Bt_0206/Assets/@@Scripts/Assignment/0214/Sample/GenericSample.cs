using UnityEngine;

namespace Bootcamp0214
{
    public class GenericSample : MonoBehaviour
    {
        private void Start()
        {
            string[] arr = new string[5] { "h", "e", "l", "l", "o" };
            PrintArray(arr);
        }

        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Debug.Log(array[i]);
            }
        }

    }
}
