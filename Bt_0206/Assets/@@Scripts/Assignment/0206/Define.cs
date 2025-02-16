using UnityEngine;

public static class Define 
{
    #region temp
    //이거, 나중에 json 파일로 만들거라서 임시로 체크용 
    public static string UI_NAME_MENU = "메뉴";
    public static string UI_NAME_ENCHANT = "강화";

    public static string LOGIN_HEADER = "로그인 방법을 선택해주세요.";
    public static string LOGIN_TEXT_GOOGLE = "구글 계정으로 로그인하기";
    public static string LOGIN_TEXT_FACEBOOK = "페이스북 계정으로 로그인하기";
    public static string LOGIN_TEXT_KAKAO = "카카오 계정으로 로그인하기";
    public static string LOGIN_TEXT_NAVER = "네이버 계정으로 로그인하기";


    public static string LOGIN_ICON_GOOGLE = "Sprites/Login/icon_google";
    public static string LOGIN_ICON_FACEBOOK = "Sprites/Login/icon_facebook";
    public static string LOGIN_ICON_KAKAO = "Sprites/Login/icon_kakao";
    public static string LOGIN_ICON_NAVER = "Sprites/Login/icon_naver";

    public static string UI_ICON_MENU = "Sprites/UI/UI_Menu";
    public static string UI_ICON_ENCHANT = "Sprites/UI/UI_Enchant";

    public static string PATH_SOUND_BGM = "Sound/BGM";
    public static string PATH_SOUND_SFX = "Sound/SFX";

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

    public static AudioClip GetSFX(SFXSoundType soundType)
    {
        AudioClip clip = null;
        string fileName = "/" + soundType.ToString();
        clip = Resources.Load<AudioClip>(PATH_SOUND_SFX + fileName + ".wav");
        return clip;
    }
    public static AudioClip GetBGM(BGMSoundType soundType)
    {
        AudioClip clip = null;

        switch (soundType)
        {
            case BGMSoundType.Ambient:
                clip = Resources.Load<AudioClip>(PATH_SOUND_BGM + "/" + "NightAmbient.wav");
                break;
            case BGMSoundType.NightAmbient:
                clip = Resources.Load<AudioClip>(PATH_SOUND_BGM + "/" + "Ambient1.wav");
                break;
            default:
                break;
        }
        return clip;
    }

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
    Epic,
}

public enum SFXSoundType
{
    BoomCharge,
    Complete,
    Death,
    Explosion,
    Strange,
    Victory,

}

public enum BGMSoundType
{
    Ambient,
    NightAmbient,
}

public enum LoadingType
{
    Scene,
    Download,
}

public enum PopupType
{
    Sleep,
    TV,
    Dead,
    Damage, //temp
}

public enum QuestRequireType
{
    Kill,
    Collect,
    Fly,

}
#endregion