using UnityEngine;

/// <summary>
/// ����Ʈ ���� �÷��̾� 
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
