using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Bootcamp/Audio/Event", fileName = "AudioEvent_")]
public class AudioEventSO : ScriptableObject
{
    public event Action<string> OnPlay;

    public void Play(string name)
    {
        if(OnPlay != null)
        {
            OnPlay?.Invoke(name);
        }
    }
}
