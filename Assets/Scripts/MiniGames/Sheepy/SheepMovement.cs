using System;
using System.Collections;
using System.Collections.Generic;
using Pets;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using Random = UnityEngine.Random;

namespace MiniGames.Sheepy
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private GameObject pet;
        
        [SerializeField] private GameObject sheepPrefab;

        public List<GameObject> allSheep;

        [SerializeField] private Transform targetPoint;

        [SerializeField] private float sThreshold; //SUPERB!!!
        [SerializeField] private float aThreshold; //Awesome :)
        [SerializeField] private float bThreshold; //u da Bomb
        [SerializeField] private float cThreshold; //Cutie
        [SerializeField] private float fThreshold; //you're still my Favorite, []

        [SerializeField] private int grade; //0 = s, 1 = a, 2 = b, 3 = c, 4 = f
        [SerializeField] private int score;

        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject gameOverPanel;

        [SerializeField] private float baseMoveSpeed;
        [SerializeField] private float moveSpeed;

        private void StartGame()
        {
            menuPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            allSheep = new List<GameObject>();
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
            moveSpeed = baseMoveSpeed + 0.01f * Time.time;
            
            foreach (var sheep in allSheep)
            {
                sheep.transform.Translate(moveSpeed * Time.deltaTime,0f,0f);
            }
        }


        public void SpawnSheep()
        {
            allSheep.Add(Instantiate(sheepPrefab));
        }

        public void DeleteSheep()
        {
            allSheep.Remove(allSheep[0]);
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
                GameOver();
                DeleteSheep();
            }
        }

        private void SheepJump()
        {
            allSheep[0].GetComponent<Animator>().SetTrigger(0);
            if (2 * grade >= 0)
            {
                score += 5 - 2 * grade;
            }
        }

        private void GameOver()
        {
            pet.GetComponent<PetScript>().information.sleepy += score;
            gameOverPanel.SetActive(true);
        }

        public void Play() //button
        {
            StartGame();
        }
    }
}
