using System;
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
    }

    private void Update()
    {
        if (currentQuest != null && true == currentQuest.questRequirement.IsReached())
        {
            //quest finished
            if(true == currentQuest.isActive)
            {
                currentQuest.questRequirement.UnRegisterEvents();
                UIPanelManager.UIToolBar.SetActiveQuestNewIcon(true);
                currentQuest.isActive = false;
            }
        }
    }

    public QuestSO CurrentQuest
    {
        get
        {
            return currentQuest;
        }
        set
        {
            currentQuest = value;
        }
    }

    private void InitQuestList()
    {
        QuestSO[] arr = Resources.LoadAll<QuestSO>("SO/Quest");

        for (int i = 0; i < arr.Length; i++) 
        {
            questDict.Add(arr[i].questID ,arr[i]);
        }

        
    }

    public void SetCurrentQuest(int questID)
    {
        if(currentQuest != null)
        {
            if(currentQuest.questID == questID)
            {
                return;
            }
            else
            {
                //25.02.13 @tk 일단 단일 퀘스트만 구현
                return;
            }
        }

        currentQuest = questDict[questID];
        currentQuest.questRequirement.Initialize();
        currentQuest.isActive = true;
        UIPanelManager.UIToolBar.SetActiveQuestNewIcon(true);

    }

    public void QuestTrigger(int questID)
    {
        if(false == questDict.ContainsKey(questID))
        {
            return;
        }
        SetCurrentQuest(questID);

        if(true == currentQuest.isDialouge)
        {
            UIPanelManager.UIDialoguePanel?.OnDialoguePanel(currentQuest.questDialouge);
        }
    }

    public void QuestRequireUpdate(QuestRequireType type, int amount)
    {
        if (currentQuest == null)
        {
            return;
        }

        OnRequireUpdated?.Invoke(type, amount);
    }

    public event Action<QuestRequireType, int> OnRequireUpdated;
    
    private QuestSO currentQuest;

    private Dictionary<int, QuestSO> questDict = new Dictionary<int, QuestSO>();

}
