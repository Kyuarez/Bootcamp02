using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Quest/Requirement", fileName = "Requirement_")]
public class QuestRequirementSO : ScriptableObject
{
    public bool isSuccessed;
}