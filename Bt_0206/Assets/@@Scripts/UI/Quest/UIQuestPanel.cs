using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI questTitleText;
    [SerializeField] private TextMeshProUGUI questDescText;
    [SerializeField] private TextMeshProUGUI questRequirementText;
    [SerializeField] private Slider achievementSlider;
    [SerializeField] private Button btn_complete;

    public void SetActiveQuestPanel() 
    {
        RequireQuestData();
        UIPanelManager.UIToolBar.SetActiveQuestNewIcon(false);
        panel.SetActive(true);
    }

    private void ResetQuestPanel()
    {
        characterImage.sprite = null;
        questTitleText.text = "[Äù½ºÆ®]";
        questDescText.text = "Äù½ºÆ® ¾ø´Âµ¥¿ä";
        questRequirementText.text = string.Empty;
        achievementSlider.value = 0;
        btn_complete.interactable = false;
    }

    public void RequireQuestData()
    {
        QuestSO questSO = QuestManager.Instance.CurrentQuest;
        if (questSO == null) 
        {
            ResetQuestPanel();
            return;
        }

        SetQuestPanel(questSO.questInfo);
        SetQuestProgress(questSO);
    }

    public void SetQuestPanel(QuestInfo questInfo)
    {
        characterImage.sprite = questInfo.questClientSprite;
        questTitleText.text = questInfo.questTitle;
        questDescText.text = questInfo.questDesc;
    }

    public void SetQuestProgress(QuestSO quest)
    {
        if(true == quest.questRequirement.IsReached())
        {
            btn_complete.interactable = true;
        }
        questRequirementText.text = string.Format(quest.questInfo.questRequireDesc, quest.questRequirement.requireAmount, quest.questRequirement.currentAmount);
        achievementSlider.value = quest.questRequirement.GetProgressPercent();

    }

    #region OnClick
    public void OnClickExitButton()
    {
        ResetQuestPanel();
        panel.SetActive(false);
    }

    public void OnClickCompleteButton()
    {
        //ÆË¾÷ ¾Ë¶÷
        ResetQuestPanel();
        UIPanelManager.UIPopup.OnPopupUI(QuestManager.Instance.CurrentQuest.questReward.GetRewardToText());
        QuestManager.Instance.CurrentQuest = null;
    }
    #endregion
}
