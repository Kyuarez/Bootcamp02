using UnityEngine;
using UnityEngine.EventSystems;

namespace Bootcamp0212
{
    public class UnityInterface : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"{eventData.position} Å¬¸¯!");
        }
    }

}
