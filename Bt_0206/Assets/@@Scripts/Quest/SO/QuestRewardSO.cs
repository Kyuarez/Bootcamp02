
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Quest/Reward", fileName = "Reward_")]
public class QuestRewardSO : ScriptableObject
{
    public int exp;
    public int coin;
}
