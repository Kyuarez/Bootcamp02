using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class MeetEvent
{

    public delegate void MeetEventHandler(string message);
    public event MeetEventHandler meetHandler;

    public void Meet()
    {
        meetHandler("���� �͵� �ο��ε�");
    }
}

public class UnityDelegateEventSample : MonoBehaviour
{
    public Text messageUI;
    MeetEvent meetEvent = new MeetEvent();

    private void Start()
    {
        meetEvent.meetHandler += EventMessage;
    }

    private void EventMessage(string message)
    {
        messageUI.text = message;
    }

    public void OnMeetButtonEnter()
    {
        meetEvent.Meet();
    }
}
