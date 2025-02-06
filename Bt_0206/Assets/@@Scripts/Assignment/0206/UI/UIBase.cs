using UnityEngine;

/// <summary>
/// @TK : UI 베이스 (UIType, 제목 등등)
/// </summary>
public class UIBase : MonoBehaviour
{
    public string uiHeader;
    public UIType uiType;

    public virtual void UIInitialize()
    {

    }
}
