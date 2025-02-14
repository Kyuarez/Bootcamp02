using UnityEngine;

public class UserDataSystem : MonoBehaviour
{
    public UserData userData01;
    public UserData userData02;

    private void Start()
    {
        userData01 = new UserData();
        userData02 = new UserData("020303", "kyu", "123456","sample0206@naver.com");

        string data_value = userData02.GetUserData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("Data01", data_value);
    }
}
