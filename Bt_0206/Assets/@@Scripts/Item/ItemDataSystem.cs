using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Bootcamp0206;

namespace Bootcamp0206
{
    public class ItemDataSystem : MonoBehaviour
    {
        public TMP_InputField nameInputField;
        public TMP_InputField descriptionInputField;

        //public TMP_Text text;
        //public TextMeshProUGUI text2;

        private void Start()
        {
            //nameInputField.onEndEdit.AddListener(OnValueChanged);
            nameInputField.onEndEdit.AddListener((string text) => OnValueChanged(text));
        }

        public void Sample()
        {
            Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
        }
    
        private void OnValueChanged(string text)
        {
            Debug.Log($"{text} ют╥б!");
        }
    }

}
