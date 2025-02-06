using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance {  get { return _instance; } }

    private UILobby uiLobby;
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

        uiLobby = GetComponentInChildren<UILobby>();
        uiContents = GetComponentInChildren<UIContents>();
        uiToolbar = GetComponentInChildren<UIToolbar>();

        uiContents.RegisterUI(); //ui 등록
    }

    private void Start()
    {
        ShowUI(UIType.MENU); //이거 로그인 한 뒤에 하자...
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
