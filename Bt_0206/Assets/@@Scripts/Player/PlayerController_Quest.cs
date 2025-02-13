using UnityEngine;

/// <summary>
/// 퀘스트 관련 플레이어 
/// </summary>
public partial class PlayerController : MonoBehaviour
{
    #region Temp
    private void UpdateQuestRequirement()
    {
        if(true == Input.GetKeyUp(KeyCode.Space))
        {
            QuestManager.Instance.QuestRequireUpdate(QuestRequireType.Fly, 1);
        }
    }

    #endregion
}
