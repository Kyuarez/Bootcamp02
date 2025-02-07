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
                Destroy(gameObject);  // Áßº¹ ¹æÁö
            ResetPopupUI();
        }

        public void ResetPopupUI()
        {
            popupBackground.color = new Color(0, 0, 0, 0);
            popupText.color = new Color(1, 1, 1, 0);
            popupText.text = string.Empty;
        }

        public void OnPopupUI(PopupType type)
        {
            StopAllCoroutines();
            ResetPopupUI();

            switch (type)
            {
                case PopupType.Sleep:
                    popupText.text = OnSoundText;
                    break;
                case PopupType.TV:
                    popupText.text = OnTVText;
                    break;
                default:
                    break;
            }

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

        private readonly string OnSoundText = "À½¾ÇÀÌ ³Ê¹« ÁÁ³×¿ä. ¿ëÀÌ ÀÚ°í ½Íµ¥¿ä. Zzz";
        private readonly string OnTVText = "¾ÆÀÌÄí! ±ôÂ¦ÀÌ¾ß! TV ¼Ò¸®¿¡ ±ôÂ¦ ³î¶ó¼­ ¿ëÀÌ È­³µ¾î¿ä!";
    }

}

