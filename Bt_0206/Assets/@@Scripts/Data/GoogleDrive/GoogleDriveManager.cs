using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class GoogleDriveManager : TSingleton<GoogleDriveManager>
{
    private const string animePath = "https://drive.google.com/uc?export=download&id=1mqDUJZTQ9TxbQVrFncri8Eex1MqM-Pj8";
    public VideoPlayer anime;
    public RawImage videoUI;

    public void OnDownloadAnime()
    {
        StartCoroutine(CoDownloadAnime());
    }

    private IEnumerator CoDownloadAnime()
    {
        UILoading.Instance.OnUILoading(LoadingType.Download, 0f);

        UnityWebRequest www = UnityWebRequest.Get(animePath);
        yield return www.SendWebRequest();
        while (!www.isDone) 
        {
            Debug.Log(www.downloadProgress);
            float progress = Mathf.Clamp01(www.downloadProgress / 0.9f);
            UILoading.Instance.OnUILoading(LoadingType.Download, progress);
            yield return null;
        }
        
        if(www.result == UnityWebRequest.Result.Success)
        {
            UILoading.Instance.OnUILoading(LoadingType.Download, 1f);
            yield return new WaitForSeconds(1f);
            UILoading.Instance.ResetUILoading();
            anime.url = animePath;
            anime.Prepare();
            while (!anime.isPrepared)
            {
                yield return null;
            }

            anime.Play();
            videoUI.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Debug.LogError("동영상 다운로드 실패: " + www.error);
        }
    }
}
