using UnityEngine;

public class QuestArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        QuestManager.Instance.QuestTrigger();
    }
}
