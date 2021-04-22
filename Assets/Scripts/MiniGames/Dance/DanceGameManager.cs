using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Dance
{
    public class DanceGameManager : MonoBehaviour
    {

        [SerializeField] private DanceGameMenu danceGameMenu;
        
        public GameObject gameButtonPrefab;

        public List<ButtonSetting> buttonSettings;

        public Transform gameFieldPanelTransform;

        public List<GameObject> gameButtons;

        [SerializeField] int bleepCount = 1;

        List<int> bleeps;
        List<int> playerBleeps;

        System.Random rg;

        public bool inputEnabled = false;
        public bool gameOver = false;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clip1;
        [SerializeField] private AudioClip clip2;
        [SerializeField] private AudioClip clip3;
        [SerializeField] private AudioClip clip4;

        public int maxBleeps;

        [SerializeField] private string[] words;
        private string theWord;


        private void Update()
        {
            /*if (bleeps.Count == maxBleeps + 1)
            {
                GameWon();
            }*/
        }

        public void StartGame()
        {
            theWord = words[Random.Range(0,words.Length)];
            gameButtons = new List<GameObject>();

            CreateGameButton(0, new Vector3(-64, 64));
            CreateGameButton(1, new Vector3(64, 64));
            CreateGameButton(2, new Vector3(-64, -64));
            CreateGameButton(3, new Vector3(64, -64));

            StartCoroutine(SimonSays());
        }

        void CreateGameButton(int index, Vector3 position) {
            GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

            gameButton.transform.SetParent(gameFieldPanelTransform);
            gameButton.transform.localPosition = position;

            gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
            gameButton.GetComponent<Button>().onClick.AddListener(() => {
                OnGameButtonClick(index);
            });

            gameButtons.Add(gameButton);
        }

        public void PlayAudio(int index)
        {
            switch (index)
            {
                case 0:
                    audioSource.PlayOneShot(clip1);
                    break;
                case 1:
                    audioSource.PlayOneShot(clip2);
                    break;
                case 2:
                    audioSource.PlayOneShot(clip3);
                    break;
                case 3:
                    audioSource.PlayOneShot(clip4);
                    break;
                default:
                    print("index out of bound, no sound to play");
                    break;
            }
        }

        void OnGameButtonClick(int index) {
            if(!inputEnabled) {
                return;
            }

            Bleep(index);

            playerBleeps.Add(index);

            if(bleeps[playerBleeps.Count - 1] != index) {
                danceGameMenu.GameOver();
                return;
            }
            else if(bleeps.Count == playerBleeps.Count && bleeps.Count < maxBleeps) 
            {
                StartCoroutine(SimonSays());
            }
            else if (bleeps.Count == playerBleeps.Count && bleeps.Count >= maxBleeps)
            {
                danceGameMenu.GameWon();
            }
        }

        

        IEnumerator SimonSays() {
            /*if (bleeps.Count >= maxBleeps)
            {
                GameWon();
            }*/

            inputEnabled = false;

            rg = new System.Random(theWord.GetHashCode());

            SetBleeps();

            yield return new WaitForSeconds(1f);

            for(int i = 0; i < bleeps.Count; i++) {
                Bleep(bleeps[i]);

                yield return new WaitForSeconds(0.6f);
            }

            inputEnabled = true;

            yield return null;
        }

        void Bleep(int index)
        {
            StartCoroutine("ColorHighlight", index);
            PlayAudio(index);
        }

        private IEnumerator ColorHighlight(int index)
        {
            gameButtons[index].GetComponent<Image>().color = buttonSettings[index].highlightColor;
            yield return new WaitForSeconds(0.5f);
            gameButtons[index].GetComponent<Image>().color = buttonSettings[index].normalColor;
        }

        void SetBleeps() {
            bleeps = new List<int>();
            playerBleeps = new List<int>();

            for(int i = 0; i < bleepCount; i++) {
                bleeps.Add(rg.Next(0, gameButtons.Count));
            }

            bleepCount++;
        }
    }
}