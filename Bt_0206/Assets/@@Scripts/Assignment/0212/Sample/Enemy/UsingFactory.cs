using UnityEngine;

namespace Bootcamp0212
{
    public class UsingFactory : MonoBehaviour
    {
        EnemyFactory enemyFactory = new EnemyFactory();

        private void Start()
        {
            IEnemy enemy = enemyFactory.Create(EnemyType.Goblin);
            enemy.Action();
            IEnemy enemy2 = enemyFactory.Create(EnemyType.Slime);
            enemy2.Action();
            IEnemy enemy3 = enemyFactory.Create(EnemyType.Wolf);
            enemy3.Action();
        }
    }
}

