using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoomController : MonoBehaviour, IScrollHandler
{
    private Camera cam;

    public void OnScroll(PointerEventData eventData)
    {
               
    }

    private const float FOV_MIN = 30f;
    private const float FOV_MAX = 90f;
}
