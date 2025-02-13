using UnityEngine;

namespace Test
{
    public class UITest : MonoBehaviour
    {
        public void OnClickStartDialogue()
        {
            DialogueManager.Instance.OnDialogue();
        }

    }

}
