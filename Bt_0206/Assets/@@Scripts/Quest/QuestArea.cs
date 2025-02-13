using UnityEngine;

public class QuestArea : MonoBehaviour
{
    public int questID;

    private void OnTriggerEnter(Collider other)
    {
        QuestManager.Instance.QuestTrigger(questID);
        Destroy(gameObject, 0.5f);
    }
}
