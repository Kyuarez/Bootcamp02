using UnityEngine;

class Unit
{
    public string unit_name; //�ʵ�
    public void UnitShout() //�޼ҵ�
    {
        Debug.Log("������ ��� ¢���ϴ�..");
    }

    public static void UnitAction() //�޼ҵ�
    {
        Debug.Log("������ �����մϴ�.");
    }
    
}

public class ClassSample : MonoBehaviour
{
    Unit unit;
    

    void Start()
    {
        unit.unit_name = "MiniGun";

        unit.UnitShout();
        
    }

    void Update()
    {
        
    }
}
