using UnityEngine;
using UnityEngine.UI;

public class UIToolBar : MonoBehaviour
{
    [SerializeField] private GameObject questNewIcon;

    public void OnClickQuestButton()
    {
        UIPanelManager.UIQuestPanel?.SetActiveQuestPanel();
        if(questNewIcon.activeSelf == true)
        {
            SetActiveQuestNewIcon(false);
            QuestManager.Instance.IsNewQuest = false;
        }
    }

    public void SetActiveQuestNewIcon(bool active)
    {
        questNewIcon.SetActive(active);
    }
}
