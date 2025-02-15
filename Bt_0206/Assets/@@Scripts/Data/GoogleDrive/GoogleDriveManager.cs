using System.Collections;
using System.ComponentModel;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class GoogleDriveManager : TSingleton<GoogleDriveManager>
{
    private const string animePath = "https://drive.usercontent.google.com/u/0/uc?id=1w0X-4ENjXa1jcCLWAHQEkTwlIOtesEgD&export=download";
    public VideoPlayer anime;
    public RawImage videoUI;

    public void OnDownloadAnime()
    {
        StartCoroutine(CoDownloadData());
    }

    private void PlayVideo(string filePath)
    {
        anime.url = "file://" + filePath;
        anime.Prepare();
        StartCoroutine(WaitForPrepareVideoCo());
    }
    IEnumerator WaitForPrepareVideoCo()
    {
        while (!anime.isPrepared)
        {
            yield return null;
        }

        anime.Play();
        videoUI.color = new Color(1, 1, 1, 1);
    }

    public IEnumerator CoDownloadDataHead()
    {
        UnityWebRequest www = UnityWebRequest.Head(animePath); //��ü ����
        www.SetRequestHeader("Range", "bytes=0-1024");
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.Success)
        {
            //"bytes 0-1024/12738898" �̷� �������� ��.
            string contentLength = www.GetResponseHeader("Content-Range");
            
            if(false == string.IsNullOrEmpty(contentLength))
            {
                string[] contentArr = contentLength.Split('/');
                string contentSize = contentArr[contentArr.Length - 1]; 
                long dataSize = long.Parse(contentSize);
                UIDownloadPopup.Instance.SetPopupTextByDataSize(dataSize);
            }
            else
            {
                Debug.Log("Content-Range ����� ����.");
            }
        }
        
    }

    private IEnumerator CoDownloadData()
    {
        UILoading.Instance.OnUILoading(LoadingType.Download, 0f);

        string filePath = Path.Combine(Application.persistentDataPath, "downloadVideo.mp4");
        if (File.Exists(filePath))
        {   
            PlayVideo(filePath);
            yield break;
        }

        using (UnityWebRequest www = UnityWebRequest.Get(animePath)) //��ü ����
        {
            www.downloadHandler = new DownloadHandlerFile(filePath);

            yield return www.SendWebRequest(); //���� �ٿ�ε�

            while (!www.isDone)
            {
                float progress = Mathf.Clamp01(www.downloadProgress / 0.9f);
                UILoading.Instance.OnUILoading(LoadingType.Download, progress);
                yield return null;
            }

            if (www.result == UnityWebRequest.Result.Success)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Debug.LogError("������ �ٿ�ε� ����: " + www.error);
            }
        }

        //������ �ٿ�ε� ���� ���� �Ŀ� ��� (�ٿ�ε� �߿��� ���� ���� �����ε�.)
        UILoading.Instance.OnUILoading(LoadingType.Download, 0.9f);
        yield return new WaitForSeconds(0.5f);
        UILoading.Instance.OnUILoading(LoadingType.Download, 1.0f);
        yield return new WaitForSeconds(0.5f);
        UILoading.Instance.ResetUILoading();

        PlayVideo(filePath);

    }
}
