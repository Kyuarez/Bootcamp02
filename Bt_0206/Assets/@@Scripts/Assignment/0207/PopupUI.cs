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

        public static PopupUI Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);  // 중복 방지
            ResetPopupUI();
        }

        public void ResetPopupUI()
        {
            popupBackground.color = new Color(0, 0, 0, 0);
            popupText.color = new Color(1, 1, 1, 0);
        }

        public void OnPopupUI()
        {
            StopAllCoroutines();
            ResetPopupUI();

            StartCoroutine("CoOnPopupUI");
            
        }

        IEnumerator CoOnPopupUI()
        {
            float elapsedTime = 0;
            float a = 0;

            while (elapsedTime < duration) 
            {
                elapsedTime += Time.deltaTime;
                a = Mathf.Lerp(0f, 1f, elapsedTime / duration);
                popupBackground.color = new Color(0, 0, 0, (a * 0.7f));
                popupText.color = new Color(1, 1, 1, a);
            }
            yield return new WaitForSeconds(4.5f);
            ResetPopupUI();
        }
    }

}

