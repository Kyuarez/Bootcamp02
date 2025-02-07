using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{

    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSFX;

    public AudioClip bgm;
    public AudioClip sfx;

    private void Start()
    {

    }

    private void Update()
    {
        ////TEST
        //if(true == Input.GetKeyDown(KeyCode.B))
        //{
        //    bgm = Define.GetBGM(BGMSoundType.NightAmbient);
        //    audioSourceBGM.clip = bgm;
        //    audioSourceBGM.Play();
        //}

        //if(true == Input.GetKeyDown(KeyCode.X))
        //{
        //    sfx = Define.GetSFX(SFXSoundType.Victory);
        //    audioSourceSFX.clip = sfx;
        //    audioSourceSFX.Play();
        //}

        //if(true == Input.GetKeyDown(KeyCode.M))
        //{
        //    audioSourceBGM.Stop();
        //    audioSourceSFX.Stop();
        //    audioSourceBGM.clip = null;
        //    audioSourceSFX.clip = null;
        //    bgm = null;
        //    sfx = null;
        //}
    }

    public void SetBGMClip(AudioClip clip)
    {
        bgm = clip;
        audioSourceBGM.clip = clip;
    }

    public void PlayBGM()
    {
        audioSourceBGM.Play();
    }

    public void PauseBGM()
    {
        audioSourceBGM.Pause();
    }


    ///// <summary>
    ///// 효과음 넣기
    ///// </summary>
    //IEnumerator GetAudioClip()
    //{
    //    //UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/GleeClubPolka.mp4", AudioType.WAV);
    //    //yield return uwr;
    //    //var clip = DownloadHandlerAudioClip.GetContent(uwr);
    //    //audioSourceBGM.clip = clip;

    //    using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/GleeClubPolka.wav", AudioType.WAV))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.result == UnityWebRequest.Result.ConnectionError)
    //        {
    //            Debug.LogError(www.error);
    //        }
    //        else
    //        {
    //            audioSourceBGM.clip = DownloadHandlerAudioClip.GetContent(www);
    //            audioSourceBGM.Play();
    //        }
    //    }

    //}
}
