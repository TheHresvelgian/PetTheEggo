using System.Collections;
using UnityEngine;

namespace MiniGames.Dance
{
    public class DanceGameMenu : MonoBehaviour
    {
        [SerializeField] private DanceGameManager danceGameManager;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject wonPanel;
        [SerializeField] private GameObject lostPanel;

        [SerializeField] private int easy;
        [SerializeField] private int medium;
        [SerializeField] private int hard;

        public void SetEasy()
        {
            danceGameManager.maxBleeps = easy;
            StartCoroutine(nameof(StartSimonSays));
        }

        public void SetMedium()
        {
            danceGameManager.maxBleeps = medium;
            StartCoroutine(nameof(StartSimonSays));
        }

        public void SetHard()
        {
            danceGameManager.maxBleeps = hard;
            StartCoroutine(nameof(StartSimonSays));
        }


        private IEnumerator StartSimonSays()
        {
            menuPanel.SetActive(false);
            yield return new WaitForSeconds(1f);
            
            danceGameManager.StartGame();
        }
        
        public void GameOver() 
        {
            danceGameManager.gameOver = true;
            danceGameManager.inputEnabled = false;
            foreach (GameObject gameObject in danceGameManager.gameButtons)
            {
                Destroy(gameObject);
            }
            print("Game Over");
            lostPanel.SetActive(true);
        }

        public void GameWon()
        {
            danceGameManager.gameOver = true;
            danceGameManager.inputEnabled = false;
            foreach (GameObject gameObject in danceGameManager.gameButtons)
            {
                Destroy(gameObject);
            }
            print("YAY");
            wonPanel.SetActive(true);
        }

        public void ChangeDifficulty()
        {
            wonPanel.SetActive(false);
            lostPanel.SetActive(false);
            menuPanel.SetActive(true);
        }

        public void PlayAgain()
        {
            wonPanel.SetActive(false);
            lostPanel.SetActive(false);
            danceGameManager.StartGame();
        }
    }
}
