using System.Collections.Generic;
using UnityEngine;

public class DataStructureSample : MonoBehaviour
{
    public Queue<string> stringQueue = new Queue<string>();

    private void Start()
    {
        stringQueue.Enqueue("안녕하시오");
        stringQueue.Enqueue("나는 리오넬 메시를 좋아하오.");
        stringQueue.Enqueue("나는 바르셀로나 팬이오");
        stringQueue.Enqueue("나는 레알 마드리드를 정말 극혐하오");
        stringQueue.Enqueue("나는 요즘 라민 야말을 정말 좋아하오.");
        stringQueue.Enqueue("나는 요즘 비니시우스를 정말 극혐하오.");

        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());

    }


}
