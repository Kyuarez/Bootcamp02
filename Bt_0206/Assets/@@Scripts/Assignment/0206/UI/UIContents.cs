using System.Collections.Generic;
using UnityEngine;

public class UIContents : MonoBehaviour
{
    //Temp
    private UIBase currentUI;

    public UIBase CurrentUI { get { return currentUI; } }

    public void RegisterUI()
    {
        for (int i = 0; i < transform.childCount; i++) 
        {
            UIBase ui = transform.GetChild(i)?.GetComponent<UIBase>();
            if(ui == null || ui.Type == UIType.None)
            {
                continue;
            }
            uiDicts.Add(ui.Type, ui);
            ui.UIInitialize();
        }
    }

    public void ShowContentsUI(UIType uiType, out UIBase ui)
    {
        UIBase previousUI = currentUI;

        if(true == uiDicts.TryGetValue(uiType, out currentUI))
        {
            previousUI?.gameObject.SetActive(false);
            currentUI.gameObject.SetActive(true);
        }
        else
        {
            currentUI = previousUI;
        }
        ui = currentUI;

    }

    public void HideContentsUI(out UIBase ui)
    {
        UIBase previousUI = currentUI;
        currentUI = uiDicts[UIType.MENU];
        ui = currentUI;

        previousUI.gameObject.SetActive(false);
        if (false == currentUI.gameObject.activeSelf)
        {
            currentUI.gameObject.SetActive(true);
        }
    }

    Dictionary<UIType, UIBase> uiDicts = new Dictionary<UIType, UIBase>();
}
