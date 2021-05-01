using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Dance
{
    public class DanceGameManager : MonoBehaviour
    {

        [SerializeField] private DanceGameMenu danceGameMenu;

        [SerializeField] private Sprite button;
        
        public GameObject gameButtonPrefab;

        public List<ButtonSetting> buttonSettings;

        public Transform gameFieldPanelTransform;

        public List<GameObject> gameButtons;

        public int bleepCount = 1;

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

        [SerializeField] private Vector3 position1;
        [SerializeField] private Vector3 position2;
        [SerializeField] private Vector3 position3;
        [SerializeField] private Vector3 position4;


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
            bleepCount = 1;
            gameButtons = new List<GameObject>();

            CreateGameButton(0, position1);
            CreateGameButton(1, position2);
            CreateGameButton(2, position3);
            CreateGameButton(3, position4);

            StartCoroutine(SimonSays());
        }

        void CreateGameButton(int index, Vector3 position) {
            GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

            gameButton.transform.SetParent(gameFieldPanelTransform);
            gameButton.transform.localPosition = position;
            gameButton.GetComponent<Image>().sprite = button;
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
                danceGameMenu.spriteList = danceGameMenu.sad;
                danceGameMenu.Start();
                return;
            }
            else if(bleeps.Count == playerBleeps.Count && bleeps.Count < maxBleeps)
            {
                danceGameMenu.spriteList = danceGameMenu.pleased;
                danceGameMenu.Start();
                StartCoroutine(SimonSays());
            }
            else if (bleeps.Count == playerBleeps.Count && bleeps.Count >= maxBleeps)
            {
                danceGameMenu.spriteList = danceGameMenu.happy;
                danceGameMenu.Start();
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