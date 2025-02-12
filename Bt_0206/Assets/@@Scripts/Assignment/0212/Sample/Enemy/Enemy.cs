using UnityEngine;

namespace Bootcamp0212
{
    public enum EnemyType
    {
        Goblin,
        Slime,
        Wolf,
    }

    public interface IEnemy
    {
        void Action();
    }

    public class Goblin : IEnemy
    {
        public void Action() 
        {
            Debug.Log("��� ����!");
        }
    }

    public class Slime : IEnemy
    {
        public void Action() 
        {
            Debug.Log("������ ����!");
        }
    }
    public class Wolf : IEnemy
    {
        public void Action() 
        {
            Debug.Log("���� ����!");
        }
    }
}
