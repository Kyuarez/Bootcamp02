using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class OnDeadEvent
{
    public delegate void DeadEventHandler();
    public event DeadEventHandler deadHandler;

    public void OnDead()
    {
        deadHandler.Invoke();
    }
}

public class OnDamageEvent
{
    public delegate void DamageEventHandler();
    public event DamageEventHandler damageHandler;

    public void OnDamage()
    {
        damageHandler.Invoke();
    }
}
