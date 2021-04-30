using UnityEngine;

namespace MiniGames
{
    public class MazeTimer : MonoBehaviour
    {
        public static int mazeDifficulty; //0 is easy, 1 is medium, 2 is hard

        public float timer { get; private set; }

        [SerializeField] private float hardTimer;
        [SerializeField] private float mediumTimer;
        [SerializeField] private float easyTimer;

        private void Start()
        {
            switch (mazeDifficulty)
            {
                case 0:
                    timer = easyTimer;
                    break;
                case 1:
                    timer = mediumTimer;
                    break;
                case 2:
                    timer = hardTimer;
                    break;
                default:
                    print("fuck");
                    break;
            }
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }
    }
}
