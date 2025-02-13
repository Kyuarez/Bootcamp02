using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    public static UIToolBar UIToolBar;
    public static UIQuestPanel UIQuestPanel;
    public static UIDialoguePanel UIDialoguePanel;

    private void Awake()
    {
        UIToolBar = GetComponentInChildren<UIToolBar>();
        UIQuestPanel = GetComponentInChildren<UIQuestPanel>();
        UIDialoguePanel = GetComponentInChildren<UIDialoguePanel>();
    }
}
