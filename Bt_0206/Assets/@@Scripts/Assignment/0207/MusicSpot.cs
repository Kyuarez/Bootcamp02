using UnityEngine;
using Bootcamp0207;

public class MusicSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(true == other.gameObject.CompareTag("Player"))
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (true == other.gameObject.CompareTag("Player"))
        {

        }
    }
}
