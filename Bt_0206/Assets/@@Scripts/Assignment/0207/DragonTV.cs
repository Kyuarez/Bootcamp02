using UnityEngine;
using UnityEngine.Video;

public class DragonTV : MonoBehaviour
{
    private VideoPlayer video;

    private void Awake()
    {
        video = GetComponentInChildren<VideoPlayer>();
        video.playOnAwake = false;
        video.isLooping = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(true == other.gameObject.CompareTag("Player"))
        {
            video.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (true == other.gameObject.CompareTag("Player"))
        {
            video.Stop();
        }
    }
}
