using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace MiniGames
{
    public class MazeMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        [SerializeField] private int minIndexEasy;
        [SerializeField] private int maxIndexEasy;
        
        [SerializeField] private int minIndexMedium;
        [SerializeField] private int maxIndexMedium;
        
        [SerializeField] private int minIndexHard;
        [SerializeField] private int maxIndexHard;
        
        private void Update()
        {
            switch (MazeTimer.mazeDifficulty)
            {
                case 0:
                    text.text = "Difficulty: Easy";
                    break;
                case 1:
                    text.text = "Difficulty: Medium";
                    break;
                case 2:
                    text.text = "Difficulty: Hard";
                    break;
            }
        }

        public void SetEasy() => MazeTimer.mazeDifficulty = 0;

        public void SetMedium() => MazeTimer.mazeDifficulty = 1;

        public void SetHard() => MazeTimer.mazeDifficulty = 2;

        public void GoHome() => SceneManager.LoadScene(1);

        public void Play()
        {
            switch (MazeTimer.mazeDifficulty)
            {
                case 0:
                    SceneManager.LoadScene(Random.Range(minIndexEasy, maxIndexEasy));
                    break;
                case 1:
                    SceneManager.LoadScene(Random.Range(minIndexMedium, maxIndexMedium));
                    break;
                case 2:
                    SceneManager.LoadScene(Random.Range(minIndexHard, maxIndexHard));
                    break;
            }
        }
    }
}
