using System;
using System.Collections;
using Pets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        public SpriteList spriteList;
        [SerializeField] private Image image;
        public SpriteList normal;
        public SpriteList happy;
        public SpriteList pleased;
        public SpriteList sad;

        public void Start()
        {
            if (spriteList == null)
            {
                spriteList = normal;
            }
            switch (CreatureController.selectedPetID)
            {
                case 0:
                    image.sprite = spriteList.mochiEgg;
                    break;
                case  1:
                    image.sprite = spriteList.mochiKid;
                    break;
                case 2:
                    image.sprite = spriteList.mochiAdult;
                    break;
                case 3:
                    image.sprite = spriteList.lilmaEgg;
                    break;
                case 4:
                    image.sprite = spriteList.lilmaKid;
                    break;
                case 5:
                    image.sprite = spriteList.lilmaAdult;
                    break;
                case 6:
                    image.sprite = spriteList.nyodleEgg;
                    break;
                case 7:
                    image.sprite = spriteList.nyodleKid;
                    break;
                case 8:
                    image.sprite = spriteList.nyodleAdult;
                    break;
                default:
                    print("no pet");
                    break;
            }
        }


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

        public void GoHome() => SceneManager.LoadScene(1);
        
    }
}
