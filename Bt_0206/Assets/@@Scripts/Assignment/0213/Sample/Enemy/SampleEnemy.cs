using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bootcamp0213
{
    public class SampleEnemy : MonoBehaviour
    {
        public DropTable DropTable;

        private void Update()
        {
            if (true == Input.GetKeyDown(KeyCode.X))
            {
                Dead();
            }

            if(true == Input.GetKeyDown(KeyCode.M))
            {
                GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0, DropTable.drop_table.Count)];
                Vector3 instantVec = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
                Instantiate(dropItemPrefab, instantVec, Quaternion.identity);
            }
        }

        private void Dead()
        {
            GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0, DropTable.drop_table.Count)];
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
