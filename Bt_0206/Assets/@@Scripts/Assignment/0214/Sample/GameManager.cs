using UnityEngine;

namespace Bootcamp0214
{
    public class GameManager : TSingleton<GameManager>
    {
        public int score;

        public void PlusScore()
        {
            score++;
        }
    }

}
