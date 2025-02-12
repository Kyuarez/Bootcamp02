using UnityEngine;
using UnityEngine.EventSystems;

public class CircleClick : MonoBehaviour, IPointerClickHandler
{
    delegate void ClickHandler();
    private ClickHandler clickHandler;

    private void Start()
    {
        clickHandler = new ClickHandler(OnClick);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickHandler?.Invoke();
    }

    public void OnClickAdd() 
    {
        clickHandler += OnClick;
    }
    public void OnClickRemove()
    {
        clickHandler -= OnClick;
    }
    public void OnClickReset()
    {
        clickHandler = new ClickHandler(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Å¬¸¯!");
    }
}
