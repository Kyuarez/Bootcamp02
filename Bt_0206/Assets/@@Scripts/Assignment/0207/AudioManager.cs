using Bootcamp0207;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);  // 중복 방지

        audioSource = GetComponent<AudioSource>();
    }
    
    public void OnPlay()
    {
        audioSource.Play();
    }

    public void OnStop()
    {
        audioSource.Stop();
    }

}
