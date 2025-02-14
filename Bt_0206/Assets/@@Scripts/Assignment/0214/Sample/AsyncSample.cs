using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootcamp0214
{
    public class AsyncSample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("ÀÛ¾÷");
            Sample01();
            Debug.Log("Process A");

        }

        private async void Sample01()
        {
            Debug.Log("Process B");
            await Task.Delay(5000);
            Debug.Log("Process C");
        }
    }

}
