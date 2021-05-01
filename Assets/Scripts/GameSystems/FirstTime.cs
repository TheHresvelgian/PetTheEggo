using System;
using System.IO;
using SSS;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystems
{
    public class FirstTime : MonoBehaviour
    {
        [SerializeField] private Save save;
        
        [SerializeField] private GameObject starterPanel;
        [SerializeField] private GameObject returningPanel;
        [SerializeField] private GameObject creditsPanel;
        
       private void Start()
        {
            if (File.Exists(SaveStateSystem._dataPath))
            {
                returningPanel.SetActive(true);
            }
            else if (!File.Exists(SaveStateSystem._dataPath))
            {
                starterPanel.SetActive(true);
            }
            else
            {
                print("ERROR");
            }
        }

        public void PlayReturn()
        {
            save.LoadPlayer();
            SceneManager.LoadScene(1);
        }

        public void PlayFirst() => SceneManager.LoadScene(1);
        
        public void Credits()
        {
            creditsPanel.SetActive(true);
        }

        public void CloseCredits()
        {
            creditsPanel.SetActive(false);
        }
    }
}
