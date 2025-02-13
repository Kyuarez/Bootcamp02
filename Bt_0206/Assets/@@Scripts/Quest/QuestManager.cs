using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    { 
        get 
        {
            return instance; 
        } 
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }

        InitQuestList();
        questID = 0;
        isNewQuest = false;
    }

    public QuestSO CurrentQuest
    {
        get
        {
            return currentQuest;
        }
    }

    public bool IsNewQuest
    {
        get { return isNewQuest; }
        set 
        { 
            if(value == true && isNewQuest != value)
            {
                isNewQuest = value;
                UIPanelManager.UIToolBar.SetActiveQuestNewIcon(value);
                return;
            }

            if(value == false && isNewQuest != value)
            {
                isNewQuest = value;
                UIPanelManager.UIToolBar.SetActiveQuestNewIcon(value);
                return;
            }
        }
    }

    private void InitQuestList()
    {
        QuestSO[] arr = Resources.LoadAll<QuestSO>("SO/Quest");

        for (int i = 0; i < arr.Length; i++) 
        {
            questList.Add(arr[i]);
        }

        
    }

    public void SetCurrentQuest()
    {
        currentQuest = questList[questID];
        IsNewQuest = true;
    }

    public void QuestTrigger()
    {
        if(currentQuest != null && (currentQuest.questID == questID))
        {
            return;
        }
        SetCurrentQuest();
    }

    private int questID;

    private bool isNewQuest;

    private QuestSO currentQuest;

    private List<QuestSO> questList = new List<QuestSO>();

}
