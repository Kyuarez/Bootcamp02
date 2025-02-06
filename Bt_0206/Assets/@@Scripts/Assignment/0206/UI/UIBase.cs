using UnityEngine;

/// <summary>
/// @TK : UI 베이스 (UIType, 제목 등등)
/// </summary>
public class UIBase : MonoBehaviour
{
    public string Header;
    public UIType Type;
    public Sprite Icon;

    //데이터 넣고, 다 false
    public virtual void UIInitialize()
    {
        Header = Define.GetHeaderByUIType(Type);
        Icon = Define.GetIconByUIType(Type);
        gameObject.SetActive(false);
    }
}
