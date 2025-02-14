using TMPro;
using UnityEngine;

public class UIDownloadPopup : TSingleton<UIDownloadPopup>
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI popupText;

    public void OnDownloadPopup()
    {
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

}
