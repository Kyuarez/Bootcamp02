using System;
using UnityEngine;

namespace Bootcamp0213
{
    public enum QuestType
    {
        Normal,
        Daily,
        Weekly,
    }

    [CreateAssetMenu(menuName ="Bootcamp/Quest/Quest", fileName ="Quest_")]
    public class Quest : ScriptableObject
    {
        public QuestType questType;
        public Reward reward;
        public Requirement requirement;

        [Header("����Ʈ ����")]
        public string title;
        public string goal; //������
        [TextArea] public string description;

        public bool isSuccess; //���� ����
        public bool isProgress; //���� ����
    }

    [Serializable]
    [CreateAssetMenu(menuName ="Bootcamp/Quest/Requirement", fileName ="Requirement_")]
    public class Requirement : ScriptableObject
    {
        public int goalCount;
        public int currentCount;
    }

    [Serializable]
    [CreateAssetMenu(menuName = "Bootcamp/Quest/Reward", fileName = "Reward_")]
    public class Reward : ScriptableObject
    {
        public int money;
        public float exp;
    }
}
