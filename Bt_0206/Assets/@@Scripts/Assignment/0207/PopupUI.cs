using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bootcamp0207
{
    public class UIPopup : MonoBehaviour
    {
        private float duration = 1.0f;
        [SerializeField] private GameObject panel;
        [SerializeField] private Image popupBackground;
        [SerializeField] private TextMeshProUGUI popupText;

        private void Start()
        {
            ResetPopupUI();
        }

        public void ResetPopupUI()
        {
            panel.SetActive(false);
            popupBackground.color = new Color(0, 0, 0, 0);
            popupText.color = new Color(1, 1, 1, 0);
            popupText.text = string.Empty;
        }

        public void OnPopupUI(PopupType type)
        {
            StopAllCoroutines();
            ResetPopupUI();
            
            float delay = 0f;
            switch (type)
            {
                case PopupType.Sleep:
                    popupText.text = OnSoundText;
                    delay = 4.5f;
                    break;
                case PopupType.TV:
                    popupText.text = OnTVText;
                    delay = 4.5f;
                    break;
                case PopupType.Dead:
                    popupText.text = OnDeadText;
                    delay = 4.5f;
                    break;
                case PopupType.Damage:
                    popupText.text = OnDamageText;
                    delay = 1.0f;
                    break;
                default:
                    break;
            }

            panel.SetActive(true);
            StartCoroutine(CoOnPopupUI(delay));

        }

        /// <summary>
        /// ����Ʈ reward �ӽ�, ���߿� ������ �ʿ�
        /// </summary>
        public void OnPopupUI(string reward)
        {
            StopAllCoroutines();
            ResetPopupUI();
            popupText.text = reward;
            panel.SetActive(true);
            StartCoroutine(CoOnPopupUI(1.0f));
        }

        IEnumerator CoOnPopupUI(float delay)
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
            yield return new WaitForSeconds(delay);
            ResetPopupUI();
        }

        private readonly string OnSoundText = "������ �ʹ� ���׿�. ���� �ڰ� �͵���. Zzz";
        private readonly string OnTVText = "������! ��¦�̾�! TV �Ҹ��� ��¦ ��� ���� ȭ�����!";
        private readonly string OnDeadText = "���Ӥ� ���� �׾���� ��";
        private readonly string OnDamageText = "�ƾ�! �����ݾ�!!";
    }

}

