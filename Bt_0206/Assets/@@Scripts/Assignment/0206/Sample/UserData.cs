using System;

[Serializable]
public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    public UserData()
    {
        UserID = null;
        UserName = null;
        UserPassword = null;
        UserEmail = null;
    }

    public UserData(string userID, string userName, string userPassword, string userEmail) 
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }

    public string GetUserData() => $"{UserID}, {UserName}, {UserPassword}, {UserEmail}";

    public static UserData SetUserData(string data) 
    {
        string[] data_values = data.Split(",");
        return new UserData(data_values[0], data_values[1], data_values[2], data_values[3]);
    }
    
}
