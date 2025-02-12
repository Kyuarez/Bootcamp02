using Bootcamp0207;
using UnityEngine;

public class UITestPanel : MonoBehaviour
{
    OnDeadEvent deadEvent;
    OnDamageEvent damageEvent;

    private PlayerController player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        deadEvent = new OnDeadEvent();
        damageEvent = new OnDamageEvent();

        deadEvent.deadHandler += player.OnDeadByEvent;
        damageEvent.damageHandler += player.OnDamageByEvent;
    }

    public void OnClickDead()
    {
        deadEvent.OnDead();
    }
    public void OnClickDamage()
    {
        damageEvent.OnDamage();
    }
}
