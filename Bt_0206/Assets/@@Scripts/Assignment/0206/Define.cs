using UnityEngine;

public static class Define 
{
    #region temp
    //�̰�, ���߿� json ���Ϸ� ����Ŷ� �ӽ÷� üũ�� 
    public static string UI_NAME_MENU = "�޴�";
    public static string UI_NAME_ENCHANT = "��ȭ";

    public static string LOGIN_HEADER = "�α��� ����� �������ּ���.";
    public static string LOGIN_TEXT_GOOGLE = "���� �������� �α����ϱ�";
    public static string LOGIN_TEXT_FACEBOOK = "���̽��� �������� �α����ϱ�";
    public static string LOGIN_TEXT_KAKAO = "īī�� �������� �α����ϱ�";
    public static string LOGIN_TEXT_NAVER = "���̹� �������� �α����ϱ�";


    public static string LOGIN_ICON_GOOGLE = "Sprites/Login/icon_google";
    public static string LOGIN_ICON_FACEBOOK = "Sprites/Login/icon_facebook";
    public static string LOGIN_ICON_KAKAO = "Sprites/Login/icon_kakao";
    public static string LOGIN_ICON_NAVER = "Sprites/Login/icon_naver";

    public static string UI_ICON_MENU = "Sprites/UI/UI_Menu";
    public static string UI_ICON_ENCHANT = "Sprites/UI/UI_Enchant";

    public static string GetHeaderByUIType(UIType uiType)
    {
        string header = null;
        switch (uiType)
        {
            case UIType.MENU:
                header = UI_NAME_MENU;
                break;
            case UIType.ENCHANT:
                header = UI_NAME_ENCHANT;
                break;
            default:
                break;
        }
        return header;
    }

    public static Sprite GetIconByUIType(UIType uiType)
    {
        Sprite sprite = null;
        switch (uiType)
        {
            case UIType.MENU:
                sprite = Resources.Load<Sprite>(UI_ICON_MENU);
                break;
            case UIType.ENCHANT:
                sprite = Resources.Load<Sprite>(UI_ICON_ENCHANT);
                break;
            default:
                break;
        }
        return sprite;
    }
    #endregion



}


#region TypeEnums
public enum UIType
{
    None,
    MENU,
    ENCHANT,
}

public enum ItemType
{

}

public enum ItemGradeType
{
    Normal,
    Unique,
}

#endregion