using UnityEngine;
using UnityEngine.UI;
using Bootcamp0206;
using TMPro;

public class TestUI : MonoBehaviour
{
    private const string KEY_NAME = "NAME";
    private const string KEY_DESC = "DESC";

    [SerializeField] private Button btn_Save;
    [SerializeField] private Button btn_Load;
    [SerializeField] private Button btn_Delete;

    [SerializeField] private TMP_InputField itemNameInputField;
    [SerializeField] private TMP_InputField itemDescriptionInputField;

    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;

   // private Bootcamp0206.ItemData itemData;
    private string currentItemName;
    private string currentItemDesc;

    private void Awake()
    {
        btn_Save.onClick.AddListener(OnClickSaveItemData);
        btn_Load.onClick.AddListener(OnClickLoadItemData);
        btn_Delete.onClick.AddListener(OnClickDeleteItemData);

        itemNameInputField.onEndEdit.AddListener(OnNameValuedChanged);
        itemDescriptionInputField.onEndEdit.AddListener(OnDescValuedChanged);

        //check
        CheckLoadItemData();
    }

    private void ReSetItemDataInfo()
    {
        itemName.text = "아이템 이름";
        itemDescription.text = "아이템 설명";
    }
    private void SetItemDataInfo()
    {
        itemName.text = currentItemName;
        itemDescription.text = currentItemDesc;
    }

    private void CheckLoadItemData()
    {
        if (true == PlayerPrefs.HasKey(KEY_NAME) && true == PlayerPrefs.HasKey(KEY_DESC))
        {
            btn_Load.interactable = true;
        }
        else
        {
            btn_Load.interactable = false;
        }
    }

    #region OnEvent
    private void OnClickSaveItemData()
    {
        if(currentItemName == null || currentItemDesc == null)
        {
            Debug.Log("데이터 다 넣으세요");
            return;
        }

        PlayerPrefs.SetString(KEY_NAME, currentItemName);
        PlayerPrefs.SetString(KEY_DESC, currentItemDesc);
        currentItemName = null;
        currentItemDesc = null;
        ReSetItemDataInfo();
        CheckLoadItemData();
    }
    private void OnClickLoadItemData()
    {
        string itemNameData = PlayerPrefs.GetString(KEY_NAME);
        string itemDescData = PlayerPrefs.GetString(KEY_DESC);

        currentItemName = itemNameData;
        currentItemDesc = itemDescData;
        SetItemDataInfo();
    }
    private void OnClickDeleteItemData()
    {
        PlayerPrefs.DeleteKey(KEY_NAME);
        PlayerPrefs.DeleteKey(KEY_DESC);
        currentItemName = null  ;
        currentItemDesc = null;
        ReSetItemDataInfo();
        CheckLoadItemData();
    }

    private void OnNameValuedChanged(string text)
    {
        if(text == string.Empty)
        {
            text = null;
        }

        currentItemName = text;
        itemNameInputField.text = null;
    }
    private void OnDescValuedChanged(string text)
    {
        if (text == string.Empty)
        {
            text = null;
        }

        currentItemDesc = text;
        itemDescriptionInputField.text = null;
    }
    #endregion
}
