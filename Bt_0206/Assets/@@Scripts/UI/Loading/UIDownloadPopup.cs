using TMPro;
using UnityEngine;

public class UIDownloadPopup : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI popupText;

    public void OnDownloadPopup()
    {

    }

    private void SetDownloadPopup() 
    {

    }

    #region OnClick
    public void OnClickYes()
    {

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
