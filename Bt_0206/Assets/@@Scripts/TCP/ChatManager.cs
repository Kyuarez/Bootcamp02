using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Sockets;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI chatDisplay;
    public Button btn_send;

    private TK_Client chatClient;

    private void Start()
    {
        chatClient = new TK_Client();
        chatClient.Connect("127.0.0.1", 12345);

        btn_send.onClick.AddListener(SendMessage);
    }

    private void UpdateChatDisplay(string message)
    {
        chatDisplay.text += "\n" + message;
        
    }

    private void SendMessage()
    {
        if(false == string.IsNullOrEmpty(inputField.text))
        {
            chatClient.SendMessage(inputField.text);
            inputField.text = string.Empty;
        }
    }

    private void Update()
    {
        if(chatClient.MessageQueue.Count > 0)
        {
            UpdateChatDisplay(chatClient.MessageQueue.Dequeue());
        }
    }

    private void OnDestroy()
    {
        chatClient.Disconnect();
    }
}
