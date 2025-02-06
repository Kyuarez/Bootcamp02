using UnityEngine;

/// <summary>
/// @TK : UI ���̽� (UIType, ���� ���)
/// </summary>
public class UIBase : MonoBehaviour
{
    public string Header;
    public UIType Type;
    public Sprite Icon;

    //������ �ְ�, �� false
    public virtual void UIInitialize()
    {
        Header = Define.GetHeaderByUIType(Type);
        Icon = Define.GetIconByUIType(Type);
        gameObject.SetActive(false);
    }
}
