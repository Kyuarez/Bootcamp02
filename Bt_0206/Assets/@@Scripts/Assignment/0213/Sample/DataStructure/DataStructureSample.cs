using System.Collections.Generic;
using UnityEngine;

public class DataStructureSample : MonoBehaviour
{
    public Queue<string> stringQueue = new Queue<string>();

    private void Start()
    {
        stringQueue.Enqueue("�ȳ��Ͻÿ�");
        stringQueue.Enqueue("���� ������ �޽ø� �����Ͽ�.");
        stringQueue.Enqueue("���� �ٸ����γ� ���̿�");
        stringQueue.Enqueue("���� ���� ���帮�带 ���� �����Ͽ�");
        stringQueue.Enqueue("���� ���� ��� �߸��� ���� �����Ͽ�.");
        stringQueue.Enqueue("���� ���� ��Ͻÿ콺�� ���� �����Ͽ�.");

        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());

    }


}
