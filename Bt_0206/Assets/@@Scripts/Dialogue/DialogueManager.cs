using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueDataSO bundles;
    [SerializeField] private UIDialoguePanel dialoguePanel; 

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void OnDialogue()
    {
        dialoguePanel?.OnDialoguePanel(bundles);
    }


}
