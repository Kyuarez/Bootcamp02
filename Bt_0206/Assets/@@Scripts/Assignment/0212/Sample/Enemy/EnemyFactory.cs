using UnityEngine;

namespace Bootcamp0212
{
    public class EnemyFactory : MonoBehaviour
    {
        //Factory���� �ٷ�� ������ ���¸� return �ϴ� �ڵ�
        public IEnemy Create(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Goblin:
                    return new Goblin();
                case EnemyType.Slime:
                    return new Slime();
                case EnemyType.Wolf:
                    return new Wolf();
                default:
                    return null;
            }
        }
    }

}

