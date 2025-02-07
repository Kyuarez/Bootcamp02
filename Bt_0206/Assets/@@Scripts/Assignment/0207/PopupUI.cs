using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bootcamp0207
{
    public class PopupUI : MonoBehaviour
    {
        private float duration = 1.0f;
        [SerializeField] private Image popupBackground;
        [SerializeField] private TextMeshProUGUI popupText;

        private void Awake()
        {
            InitOnPopup();
        }

        public void InitOnPopup()
        {
            popupBackground.color = new Color(0, 0, 0, 0);
            popupText.color = new Color(1, 1, 1, 0);
        }

        public void OnPopupUI()
        {
            StopAllCoroutines();
            InitOnPopup();

            StartCoroutine("CoOnPopupUI");
            
        }

        IEnumerator CoOnPopupUI()
        {
            float elapsedTime = 0;
            while (elapsedTime < duration) 
            {

                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
    }

}

