using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class UILogin : MonoBehaviour
{
    public TMP_InputField inputField_id;
    public TMP_InputField inputField_password;

    public void OnclickLogin()
    {
        string userID = inputField_id.text;
        string userPassword = inputField_password.text;

        LoginPacket packet = new LoginPacket();
        packet.code = "Login";
        packet.id = userID;
        packet.password = userPassword;

        //JObject resultObject = new JObject();
        //resultObject.Add("code", "Login");
        //resultObject.Add("user_id", userID);
        //resultObject.Add("user_password", userPassword);
        
        //SendÇÏ´Â °Å
        TKNetworkManager.Instance.OnLogin(packet);

        inputField_id.text = string.Empty;
        inputField_password.text = string.Empty;
    }
}
