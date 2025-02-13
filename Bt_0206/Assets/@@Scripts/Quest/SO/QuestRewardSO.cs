
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
        return string.Format("����Ʈ ���� : ����ġ( +{0} ), ���( +{1} )", exp, coin);
    }
}
