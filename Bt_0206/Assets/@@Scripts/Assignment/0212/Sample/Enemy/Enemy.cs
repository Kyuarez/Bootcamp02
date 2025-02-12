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
            Debug.Log("고블린 등장!");
        }
    }

    public class Slime : IEnemy
    {
        public void Action() 
        {
            Debug.Log("슬라임 등장!");
        }
    }
    public class Wolf : IEnemy
    {
        public void Action() 
        {
            Debug.Log("늑대 등장!");
        }
    }
}
