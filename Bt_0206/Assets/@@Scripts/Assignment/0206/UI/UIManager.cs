using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance {  get { return _instance; } }

    private UIContents uiContents;
    private UIToolbar uiToolbar;

    private void Awake()
    {
        #region Singleton
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        #endregion

        uiContents = GetComponentInChildren<UIContents>();
        uiToolbar = GetComponentInChildren<UIToolbar>();

        uiContents.RegisterUI(); //ui µî·Ï
        ShowUI(UIType.MENU);
    }

    public void ShowUI(UIType uiType)
    {
        UIBase ui;
        uiContents.ShowContentsUI(uiType, out ui);
        uiToolbar.SetToolBar(ui.Icon, ui.Header);
    }

    public void HideUI()
    {
        UIBase ui;
        uiContents.HideContentsUI(out ui);
        uiToolbar.SetToolBar(ui.Icon, ui.Header);
    }


}
