using UnityEngine;

namespace Bootcamp0212
{
    public class UsingObserver : MonoBehaviour
    {
        delegate void NotifyHandler();
        NotifyHandler _notifyHandler;

        void Start()
        {
            Observer01 observer01 = new Observer01();
            Observer02 observer02 = new Observer02();

            _notifyHandler = new NotifyHandler(observer01.OnNotify);
            _notifyHandler += observer02.OnNotify;
        }

        void Update()
        {

        }
    }


}

