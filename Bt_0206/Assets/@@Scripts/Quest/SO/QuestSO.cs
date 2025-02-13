using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Quest/Quest", fileName ="Quest_")]
public class QuestSO : ScriptableObject
{
    public int questID;
    public QuestInfo questInfo;
    public QuestRequirementSO questRequirement;
    public QuestRewardSO questReward;

    public bool isActive; //현재 퀘스트 여부

    public bool isDialouge;
    public DialogueDataSO questDialouge;
}


[Serializable]
public class QuestInfo
{
    public string questTitle;
    public string questClientName;
    public Sprite questClientSprite;
    [TextArea] public string questDesc;
    [TextArea] public string questRequireDesc;

}
