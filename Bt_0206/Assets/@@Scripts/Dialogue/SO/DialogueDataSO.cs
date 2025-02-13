using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueBundle", fileName ="Dialogue_", order = 1)]
public class DialogueDataSO : ScriptableObject
{
    public List<DialogueData> dialogueBundles;
}

[Serializable]
public class DialogueData
{
    public string characterName;
    public List<string> dialogueBundle;
    public Sprite charactorImage;
}
