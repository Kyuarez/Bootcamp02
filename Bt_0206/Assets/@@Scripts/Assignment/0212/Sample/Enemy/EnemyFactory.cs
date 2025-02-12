using UnityEngine;

namespace Bootcamp0212
{
    public class EnemyFactory : MonoBehaviour
    {
        //Factory에서 다루는 데이터 형태를 return 하는 코드
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

