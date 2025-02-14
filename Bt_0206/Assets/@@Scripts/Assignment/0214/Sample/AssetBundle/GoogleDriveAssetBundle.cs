using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{
    private string imagePath = "https://drive.usercontent.google.com/u/0/uc?id=16KV5BAUt9sgO9iUdgyyVAHkMg3KwEtLh&export=download";

    public Image image;

    private void Start()
    {
        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        UILoading.Instance.OnUILoading(LoadingType.Download, 0f);
        //해당 웹 주소로 리퀘스트 요청
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imagePath);
        //리퀘스트 send 올때까지 대기
        yield return www.SendWebRequest();
    
        if(www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            image.sprite = sprite;
            Debug.Log("이미지 가져오기 성공");
        }
        else
        {
            Debug.LogError("이미지 가져오기 실패");
        }

    }
}
