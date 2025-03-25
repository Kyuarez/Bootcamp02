using TMPro;
using UnityEngine;

public class UISignup : MonoBehaviour
{
    public TMP_InputField inputField_id;
    public TMP_InputField inputField_password; 
    public TMP_InputField inputField_name;
    public TMP_InputField inputField_email;

    public void OnclickSignup()
    {
        SignupPacket packet = new SignupPacket();
        packet.code = "Signup";
        packet.id = inputField_id.text;
        packet.password = inputField_password.text;
        packet.name = inputField_name.text;
        packet.email = inputField_email.text;

        TKNetworkManager.Instance.OnSignup(packet);

        inputField_id.text = string.Empty;
        inputField_password.text = string.Empty;
        inputField_name.text = string.Empty;
        inputField_email.text = string.Empty;
    }
}
