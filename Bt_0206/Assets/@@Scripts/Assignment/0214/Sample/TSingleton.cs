using UnityEngine;

public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = (T)FindAnyObjectByType<T>();

                if(_instance == null)
                {
                    var manager = new GameObject(typeof(T).Name);
                    _instance = manager.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
