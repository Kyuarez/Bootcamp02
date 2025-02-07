using UnityEngine;

namespace Bootcamp0207
{
    public class SampleSoundSource : MonoBehaviour
    {
        public AudioSource ad;

        void Start()
        {
            if(ad.clip != null)
            {
                ad.Play();
                ad.volume = 1.0f;
            }

        }
    }

}

