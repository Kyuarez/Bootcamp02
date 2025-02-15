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
        //@tk (25.02.15) ���⼭ �̸� �ٿ�ε� �뷮 �޾ƿ;���.
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

    private const string DOWNLOADTEXT = "�ű� ��ġ [{0}MB]�� �ٿ�ε� �մϴ�.\nWIFI ȯ�濡�� �ٿ�ε带 ����帮��,\nWIFI �̿��� �� �����Ͱ� �����˴ϴ�.";

}
