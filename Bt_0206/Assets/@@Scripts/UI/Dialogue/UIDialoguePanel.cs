using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialoguePanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private Button btn_next;
    [SerializeField] private Button btn_skip;

    private DialogueDataSO currentBundles;
    private Queue<string> currentTextQueue = new Queue<string>();
    private int currentPage;

    private void Awake()
    {
        //��ư ���
        btn_next.onClick.AddListener(OnClickNextButton);
        btn_skip.onClick.AddListener(OnClickSkipButton);

        //������ ����
        ResetPanelData();

        //��Ȱ��ȭ
        if(panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
    }

    private void ResetPanelData()
    {
        currentBundles = null;
        currentPage = 0;
        characterImage.sprite = null;
        nameText.text = string.Empty;
        descriptionText.text = string.Empty;
        currentTextQueue.Clear();
    }

    public void OnDialoguePanel(DialogueDataSO bundles)
    {
        currentBundles = bundles;
        SetPanelData(bundles.dialogueBundles[0]);
        SetCurrentTextQueue(bundles.dialogueBundles[0]);
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        StartCoroutine(CODialogue(currentTextQueue.Dequeue()));
    }

    public void ChangeDialogueData(int page)
    {
        DialogueData data = currentBundles.dialogueBundles[page];
        SetPanelData(data);
        SetCurrentTextQueue(data);
        StartCoroutine(CODialogue(currentTextQueue.Dequeue()));
    }

    /// <summary>
    /// ĳ���� �̹���, ĳ���� �̸�
    /// </summary>
    public void SetPanelData(DialogueData data)
    {
        characterImage.sprite = data.charactorImage;
        nameText.text = data.characterName;
    }

    public void SetCurrentTextQueue(DialogueData data)
    {
        currentTextQueue.Clear();

        for (int i = 0; i < data.dialogueBundle.Count; i++)
        {
            currentTextQueue.Enqueue(data.dialogueBundle[i]);
        }
    }

    #region CO
    IEnumerator CODialogue(string text)
    {
        descriptionText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            descriptionText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    #endregion

    #region OnClick
    public void OnClickNextButton()
    {
        StopAllCoroutines();
        
        if(currentTextQueue.Count == 0)
        {
            currentPage++;
            if (currentPage >= currentBundles.dialogueBundles.Count)
            {
                //��ȭ����
                ResetPanelData();
                panel.SetActive(false);
                return;
            }

            ChangeDialogueData(currentPage);
            return;
        }

        descriptionText.text = string.Empty;
        StartCoroutine(CODialogue(currentTextQueue.Dequeue()));
    }

    public void OnClickSkipButton()
    {
        StopAllCoroutines();
        ResetPanelData();
        panel.SetActive(false);
    }
    #endregion
}
