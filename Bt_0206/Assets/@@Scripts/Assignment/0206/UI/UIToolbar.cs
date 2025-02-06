using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIToolbar : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI headerText;

    private Button btn_Back;

    public void SetToolBar(Sprite icon, string header)
    {
        iconImage.sprite = icon;
        iconImage.color = Color.black;
        headerText.text = header;
    }

}
