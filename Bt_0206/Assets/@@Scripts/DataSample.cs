using UnityEngine;

public class DataSample : MonoBehaviour
{
    public UserData userData;

    private void Start()
    {

    }

    public void RegisterPlayerInfo()
    {
        PlayerPrefs.SetString("ID", userData.UserID);
        PlayerPrefs.SetString("UserName", userData.UserName);
        PlayerPrefs.SetString("Password", userData.UserPassword);
        PlayerPrefs.SetString("Email", userData.UserEmail);
    }

    public void DebugUserData(string key)
    {
        string data = PlayerPrefs.GetString(key);
        if (data == null)
        {
            Debug.Log($"{key} is null");
            return;
        }

        Debug.Log($"{key} : {data}");
    }

    public void DeleteAllUserData()
    {
        PlayerPrefs.DeleteKey("ID");
        PlayerPrefs.DeleteKey("UserName");
        PlayerPrefs.DeleteKey("Password");
        PlayerPrefs.DeleteKey("Email");
    }

}
