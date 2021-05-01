using System;
using System.Collections;
using System.Collections.Generic;
using DataContainers;
using Pets;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MiniGames.Sheepy
{
    public class SheepMovement : MonoBehaviour
    {
        [SerializeField] private float multiplier;
        [SerializeField] private float timer;
        
        [SerializeField] private PetScrubBase thePet;
        [SerializeField] private PetScrubBase pet1;
        [SerializeField] private PetScrubBase pet2;
        [SerializeField] private PetScrubBase pet3;

        [SerializeField] private GameObject theSheep;
        [SerializeField] private GameObject rotatePrefab;

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
        

        private void Start()
        { switch (CreatureController.selectedPetID)
            {
                case 0:
                    thePet = pet1;
                    break;
                case  1:
                    thePet = pet1;
                    break;
                case 2:
                    thePet = pet1;
                    break;
                case 3:
                    thePet = pet2;
                    break;
                case 4:
                    thePet = pet2;
                    break;
                case 5:
                    thePet = pet2;
                    break;
                case 6:
                    thePet = pet3;
                    break;
                case 7:
                    thePet = pet3;
                    break;
                case 8:
                    thePet = pet3;
                    break;
                default:
                    print("no pet");
                    break;
            }
        }

        private void Update()
        {
            timer += Time.deltaTime * 0.1f;
        }

        private void StartGame()
        {
            menuPanel.SetActive(false);
            gameOverPanel.SetActive(false);
            allSheep = new List<GameObject>();
            jumpedSheep = new List<GameObject>();
            StartCoroutine(nameof(SpawnDelay));
            score = 0;
            timer = 0;
        }

        private IEnumerator SpawnDelay()
        {
            SpawnSheep();
            yield return new WaitForSeconds(Random.Range(2, 5));
            StartCoroutine(nameof(SpawnDelay));
        }
        
        public void SpawnSheep()
        {
//            print("Instantiate");
            allSheep.Add(Instantiate(rotatePrefab, new Vector3(-0.7f, -9.8f, -2f), new Quaternion(0,0,0,0)));
            
            //allSheep[allSheep.Count-1].GetComponent<Animator>().SetTrigger(1); //run
        }

       /* public void DeleteSheep()
        {
            jumpedSheep.Add(allSheep[0]);
            allSheep.Remove(allSheep[0]);
            Destroy(jumpedSheep[0].gameObject,1f);
        }*/

        public void PressJump() //button
        {
            SheepJump();
            /*var distance =  Vector3.Distance(allSheep[0].transform.GetChild(0).position, targetPoint.position);
            print(distance);
            if (distance <= sThreshold)
            {
                grade = 0;
                print("SUPERB!!!!");
                SheepJump();
                //DeleteSheep();
            }
            else if (distance <= aThreshold)
            {
                grade = 1;
                print("Awesome :)");
                SheepJump();
                //DeleteSheep();
            }
            else if (distance <= bThreshold)
            {
                grade = 2;
                print("da Bomb");
                SheepJump();
                //DeleteSheep();
            }
            else if (distance <= cThreshold)
            {
                grade = 3;
                print("Cutie");
                SheepJump();
               // DeleteSheep();
            }
            else if (distance <= fThreshold)
            {
                grade = 4;
                print("you're still my Favorite, []");
                StartCoroutine(nameof(GameOver));
                //DeleteSheep();
            }
            else
            {
                print("??");
            }*/
        }

        private void SheepJump()
        {
            allSheep[0].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Jump"); 
            allSheep[0].transform.GetChild(0).GetComponent<JumpScript>().Jump();
            score += 5;
            Destroy(allSheep[0].gameObject,1f);
            allSheep.Remove(allSheep[0]);
        }

        public IEnumerator GameOver()
        {
            playerInputPanel.SetActive(false);
            allSheep[0].transform.GetChild(0).GetComponent<Animator>().SetTrigger("Jump"); //jump
            yield return new WaitForSeconds(1f);
            foreach (var sheep in allSheep)
            {
                sheep.transform.GetChild(0).GetComponent<Animator>().SetTrigger("GameOver");//x_x
            }
            foreach (var sheep in jumpedSheep)
            {
                sheep.transform.GetChild(0).GetComponent<Animator>().SetTrigger("GameOver");//x_x
            }
            
            thePet.sleepy += score;
            gameOverPanel.SetActive(true);
        }

        public void Play() //button
        {
            print("Play");
            StartGame();
        }
    }
}