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
        panel.SetActive(true);
    }

    private void ResetQuestPanel()
    {
        characterImage.sprite = null;
        questTitleText.text = "[Äù½ºÆ®]";
        questDescText.text = "Äù½ºÆ® ¾ø´Âµ¥¿ä";
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
    }

    public void SetQuestPanel(QuestInfo questInfo)
    {
        characterImage.sprite = questInfo.questClientSprite;
        questTitleText.text = questInfo.questTitle;
        questDescText.text = questInfo.description;

    }

    public void OnClickExitButton()
    {
        ResetQuestPanel();
        panel.SetActive(false);
    }
}
