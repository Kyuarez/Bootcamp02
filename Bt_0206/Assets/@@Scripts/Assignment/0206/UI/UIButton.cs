using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public UIType targetUI;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();   
        button.onClick.AddListener(() => OnClickBtn(targetUI));
    }

    private void OnClickBtn(UIType uiType)
    {
        UIManager.Instance.ShowUI(uiType);
    }
}
