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

        [Header("퀘스트 정보")]
        public string title;
        public string goal; //소제목
        [TextArea] public string description;

        public bool isSuccess; //성공 여부
        public bool isProgress; //진행 여부
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
