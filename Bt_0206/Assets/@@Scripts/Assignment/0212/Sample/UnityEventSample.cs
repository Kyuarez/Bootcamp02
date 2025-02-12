using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bootcamp0212
{
    class SpecialPortalEvent
    {
        public event EventHandler kill;

        int count = 0;

        public void OnKIll()
        {
            CountPlus();
            if(count == 3)
            {
                count = 0;
                kill(this, EventArgs.Empty); //�̺�Ʈ �߻�
            }
        }

        public void CountPlus()
        {
            count++;
        }
    }

    public class UnityEventSample : MonoBehaviour
    {
        SpecialPortalEvent specialPortalEvent = new SpecialPortalEvent();
        

        void Start()
        {
            specialPortalEvent.kill += new EventHandler(MonsterKill); //�̺�Ʈ ���
            for (int i = 0; i < 3; i++)
            {
                specialPortalEvent.OnKIll();
            }
        }

        private void MonsterKill(object sender, EventArgs e) //�̺�Ʈ ���� �� ȣ��
        {
            Debug.Log("��Ż�� ���Ƚ��ϴ�.");
        }
    }

}

