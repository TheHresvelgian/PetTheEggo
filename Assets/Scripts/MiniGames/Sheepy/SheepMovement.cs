using System.Collections;
using System.Collections.Generic;
using Pets;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniGames.Sheepy
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private float multiplier;
        
        [SerializeField] private GameObject pet;
        
        [SerializeField] private GameObject sheepPrefab;

        public List<GameObject> allSheep;
        public List<GameObject> jumpedSheep;

        [SerializeField] private Transform targetPoint;

        [SerializeField] private float sThreshold; //SUPERB!!!
        [SerializeField] private float aThreshold; //Awesome :)
        [SerializeField] private float bThreshold; //u da Bomb
        [SerializeField] private float cThreshold; //Cutie
        [SerializeField] private float fThreshold; //you're still my Favorite, []

        [SerializeField] private int grade; //0 = s, 1 = a, 2 = b, 3 = c, 4 = f
        [SerializeField] private int score;

        [SerializeField] private GameObject playerInputPanel;
        
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject gameOverPanel;

        [SerializeField] private float baseMoveSpeed;
        [SerializeField] private float moveSpeed;

        private void StartGame()
        {
            menuPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            allSheep = new List<GameObject>();
            jumpedSheep = new List<GameObject>();
            StartCoroutine(nameof(SpawnDelay));
            score = 0;
        }

        private IEnumerator SpawnDelay()
        {
            SpawnSheep();
            yield return new WaitForSeconds(Random.Range(0, 3));
            StartCoroutine(nameof(SpawnDelay));
        }

        private void Update()
        {
            moveSpeed = baseMoveSpeed + multiplier * Time.time;
            
            foreach (var sheep in allSheep)
            {
                sheep.transform.Translate(moveSpeed * Time.deltaTime,0f,0f);
            }

            foreach (var sheep in jumpedSheep)
            {
                sheep.transform.Translate(moveSpeed * Time.deltaTime,0f,0f);
                
            }
        }
        
        public void SpawnSheep()
        {
            allSheep.Add(Instantiate(sheepPrefab));
            allSheep[allSheep.Count-1].GetComponent<Animator>().SetTrigger(1); //run
        }

        public void DeleteSheep()
        {
            jumpedSheep.Add(allSheep[0]);
            allSheep.Remove(allSheep[0]);
            Destroy(jumpedSheep[0],5f);
        }

        public void PressJump() //button
        {
            var distance =  Vector3.Distance(allSheep[0].transform.position, targetPoint.position);
            if (distance <= sThreshold)
            {
                grade = 0;
                print("SUPERB!!!!");
                SheepJump();
                DeleteSheep();
            }
            else if (distance <= aThreshold)
            {
                grade = 1;
                print("Awesome :)");
                SheepJump();
                DeleteSheep();
            }
            else if (distance <= bThreshold)
            {
                grade = 2;
                print("da Bomb");
                SheepJump();
                DeleteSheep();
            }
            else if (distance <= cThreshold)
            {
                grade = 3;
                print("Cutie");
                SheepJump();
                DeleteSheep();
            }
            else if (distance <= fThreshold)
            {
                grade = 4;
                print("you're still my Favorite, []");
                StartCoroutine(nameof(GameOver));
                DeleteSheep();
            }
        }

        private void SheepJump()
        {
            allSheep[0].GetComponent<Animator>().SetTrigger(0); //jump
            if (2 * grade >= 0)
            {
                score += 5 - 2 * grade;
            }
        }

        private IEnumerator GameOver()
        {
            playerInputPanel.SetActive(false);
            allSheep[0].GetComponent<Animator>().SetTrigger(0); //jump
            yield return new WaitForSeconds(1f);
            foreach (var sheep in allSheep)
            {
                sheep.GetComponent<Animator>().SetTrigger(2);//x_x
            }
            pet.GetComponent<PetScript>().information.sleepy += score;
            gameOverPanel.SetActive(true);
        }

        public void Play() //button
        {
            StartGame();
        }
    }
}
