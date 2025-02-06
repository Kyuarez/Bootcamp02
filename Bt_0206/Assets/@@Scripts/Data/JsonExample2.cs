using System.IO;
using UnityEngine;

namespace Bootcamp0206
{
    [System.Serializable]
    public class SampleItem
    {
        public string name;
        public string description;
    }

    public class JsonExample2 : MonoBehaviour
    {
        private void Start()
        {
            string load_json = File.ReadAllText(Application.streamingAssetsPath + "/Sample/sampleItem.json");
            var data = JsonUtility.FromJson<SampleItem>(load_json);
            Debug.Log(data.name);
            Debug.Log(data.description);
        }

        
    }
}


