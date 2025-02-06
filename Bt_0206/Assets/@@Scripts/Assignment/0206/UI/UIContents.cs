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
            if(ui == null || ui.uiType == UIType.None)
            {
                continue;
            }

            uiDicts.Add(ui.uiType, ui);
        }
    }

    Dictionary<UIType, UIBase> uiDicts = new Dictionary<UIType, UIBase>();
}
