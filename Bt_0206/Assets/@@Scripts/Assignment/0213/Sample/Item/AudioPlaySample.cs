using UnityEngine;

namespace Bootcamp0213
{
    public class AudioPlaySample : MonoBehaviour
    {
        public AudioEventSO audioEvent;
        public ItemSO item;


        private void Start()
        {
            audioEvent.OnPlay += PlaySound;
        }

        private void Update()
        {
            if (true == Input.GetKeyDown(KeyCode.A))
            {
                audioEvent.Play("등장 배경음");
            }
            if(true == Input.GetKeyDown(KeyCode.W))
            {
                DropItem();
            }
        }


        private void DropItem()
        {
            GameObject obj = Instantiate(item.ItemBody, transform.position, Quaternion.identity);
            obj.name = item.name;
            Destroy(gameObject);
        }

        public void PlaySound(string soundName)
        {
            Debug.Log(soundName + "플레이 중");
        }
    }
}

