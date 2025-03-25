using TMPro;
using UnityEngine;

public class UIChat : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI chatText;

    public void UpdateChat(string message)
    {
        chatText.text = chatText.text + "\n" + message;
    }

    public void OnClickChat() 
    {
        string message = inputField.text;
        ChatPacket packet = new ChatPacket();
        packet.code = "Chat";
        packet.id = "Unity";
        packet.message = message;
        TKNetworkManager.Instance.OnChat(packet);
        inputField.text = string.Empty;
    }

}
