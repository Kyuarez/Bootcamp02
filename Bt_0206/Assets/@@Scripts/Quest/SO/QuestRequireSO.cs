using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Quest/Requirement", fileName = "Requirement_")]
public class QuestRequirementSO : ScriptableObject
{
    public QuestRequireType requireType;
    public int requireAmount;
    public int currentAmount;
    public void Initialize()
    {
        currentAmount = 0;
        QuestManager.Instance.OnRequireUpdated += OnRequirementUpdated;
    }
    private void OnRequirementUpdated(QuestRequireType type, int amount)
    {
        if (type == requireType)
        {
            currentAmount += amount;
        }
    }
    public void UnRegisterEvents()
    {
        QuestManager.Instance.OnRequireUpdated -= OnRequirementUpdated;
    }
    public bool IsReached()
    {
        return (currentAmount >= requireAmount);
    }

    public float GetProgressPercent()
    {
        if(currentAmount == 0)
        {
            return 0f;
        }

        return (float)Math.Round(((double)currentAmount / requireAmount), 2);
    }
}