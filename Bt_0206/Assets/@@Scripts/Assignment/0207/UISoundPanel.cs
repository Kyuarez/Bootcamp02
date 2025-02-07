
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bootcamp0207
{
    public class UISoundPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentSoundText;
        [SerializeField] private TextMeshProUGUI playStateText;
        [SerializeField] private Button btn_Play;
        [SerializeField] private Button btn_Pause;

        public AudioClip currentClip;
        private AudioSourceSample audioSource;

        private void Awake()
        {
            audioSource = GameObject.Find("AudioSourceSample").GetComponent<AudioSourceSample>();
            //AudioClip clip = Define.GetBGM(BGMSoundType.Ambient);
            audioSource.SetBGMClip(currentClip);
            SetCurrentSound(currentClip);
            SetPlayStateSound(false);
        }

        public void SetCurrentSound(AudioClip clip)
        {
            currentClip = clip;
            currentSoundText.text = clip.name;
        }
        public void SetPlayStateSound(bool isPlay)
        {
            if(true == isPlay)
            {
                playStateText.text = "Àç»ý Áß";
            }
            else
            {
                playStateText.text = "¸ØÃã";
            }
        }

        public void OnClickPlay()
        {
            audioSource.PlayBGM();
            SetPlayStateSound(true);
        }

        public void OnClickPause() 
        {
            audioSource.PauseBGM();
            SetPlayStateSound(false);
        }
    }

}
