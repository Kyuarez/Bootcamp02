using System.Collections;
using TMPro;
using UnityEngine;

public class UIDownloadPopup : TSingleton<UIDownloadPopup>
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI popupText;

    public void OnDownloadPopup()
    {
        StartCoroutine(OnDownloadPopupCo());
    }

    public void SetPopupTextByDataSize(long dataSize)
    {
        float fileSizeMB = dataSize / (1024 * 1024);
        popupText.text = string.Format(DOWNLOADTEXT, fileSizeMB.ToString());
    }

    IEnumerator OnDownloadPopupCo()
    {
        //@tk (25.02.15) 여기서 미리 다운로드 용량 받아와야함.
        yield return GoogleDriveManager.Instance.CoDownloadDataHead();

        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
    }

    #region OnClick
    public void OnClickYes()
    {
        GoogleDriveManager.Instance.OnDownloadAnime();
        if (panel.activeSelf != false)
        {
            panel.SetActive(false);
        }
    }

    public void OnClickNo()
    {
        if(panel.activeSelf != false)
        {
            panel.SetActive(false);
        }
    }

    #endregion

    private const string DOWNLOADTEXT = "신규 패치 [{0}MB]을 다운로드 합니다.\nWIFI 환경에서 다운로드를 권장드리며,\nWIFI 미연결 시 데이터가 차감됩니다.";

}
