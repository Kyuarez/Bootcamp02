using Bootcamp0207;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    public static UIToolBar UIToolBar;
    public static UIQuestPanel UIQuestPanel;
    public static UIDialoguePanel UIDialoguePanel;
    public static UIPopup UIPopup;

    private void Awake()
    {
        UIToolBar = GetComponentInChildren<UIToolBar>();
        UIQuestPanel = GetComponentInChildren<UIQuestPanel>();
        UIDialoguePanel = GetComponentInChildren<UIDialoguePanel>();
        UIPopup = GetComponentInChildren<UIPopup>();
    }
}
