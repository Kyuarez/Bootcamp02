using System.Collections.Generic;
using UnityEngine;

namespace Bootcamp0213
{
    [CreateAssetMenu(menuName = "Bootcamp/DropTable", fileName = "DropTable/drop table", order = 0)]
    public class DropTable : ScriptableObject
    {
        public List<GameObject> drop_table;

    }

}
