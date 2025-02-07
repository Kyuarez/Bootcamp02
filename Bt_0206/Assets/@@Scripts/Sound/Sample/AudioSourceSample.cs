using UnityEngine;

public class AudioSourceSample : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;

    public AudioClip bgm;


    private void Start()
    {
        audioSourceBGM.clip = bgm;
        audioSourceBGM.Play();
    }

    private void Update()
    {
        
    }
}
