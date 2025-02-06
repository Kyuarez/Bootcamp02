using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIContents uiContents;
    private UIToolbar uiToolbar;

    private void Awake()
    {
        uiContents = GetComponentInChildren<UIContents>();
        uiToolbar = GetComponentInChildren<UIToolbar>();
    }
}
