using UnityEngine;

class Unit
{
    public string unit_name; //필드
    public void UnitShout() //메소드
    {
        Debug.Log("유닛이 울부 짖습니다..");
    }

    public static void UnitAction() //메소드
    {
        Debug.Log("유닛이 동작합니다.");
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
