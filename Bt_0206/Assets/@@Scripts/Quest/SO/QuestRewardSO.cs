
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Quest/Reward", fileName = "Reward_")]
public class QuestRewardSO : ScriptableObject
{
    public int exp;
    public int coin;

    public string GetRewardToText()
    {
        return string.Format("퀘스트 보상 : 경험치( +{0} ), 골드( +{1} )", exp, coin);
    }
}
