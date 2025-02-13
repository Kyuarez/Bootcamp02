using UnityEngine;
using UnityEngine.UI;

public class UIToolBar : MonoBehaviour
{
    [SerializeField] private GameObject questNewIcon;

    public void OnClickQuestButton()
    {
        UIPanelManager.UIQuestPanel?.SetActiveQuestPanel();
    }

    public void SetActiveQuestNewIcon(bool active)
    {
        questNewIcon.SetActive(active);
    }
}
