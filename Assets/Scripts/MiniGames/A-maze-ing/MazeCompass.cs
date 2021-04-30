using System;
using UnityEngine;

namespace MiniGames
{
    public class MazeCompass : MonoBehaviour
    {
        [SerializeField] private Transform goal;
        [SerializeField] private Transform ownTransform;

        private void Start()
        {
            ownTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            
        }
    }
}
