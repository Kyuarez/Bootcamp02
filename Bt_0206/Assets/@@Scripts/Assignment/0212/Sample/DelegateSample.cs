using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    public delegate void Delegate01();


    private void Start()
    {
        Delegate01 dt01 = new Delegate01(Attack);
        dt01 += Defense;
        dt01 += Attack;
        dt01 += Attack;
        dt01 += Attack;
        dt01 += Attack;
        dt01 += Attack;
        dt01 -= Attack;
        dt01?.Invoke();
    }

    public void UseDelegate(Delegate01 dt)
    {
        dt?.Invoke();
    }

    Delegate01 Selection(int value)
    {
        if (value == 1)
            return Attack;
        else if (value == 2)
            return Defense;
        else
            return Idle;
    }

    void Attack()
    {
        Debug.Log("����");
    }
    void Defense()
    {
        Debug.Log("���");
    }

    void Idle()
    {
        Debug.Log("���");
    }
}
