using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDownload : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIDownloadPopup.Instance?.OnDownloadPopup();
    }
}
