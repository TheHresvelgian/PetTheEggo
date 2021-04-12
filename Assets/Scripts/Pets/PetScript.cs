using System;
using DataContainers;
using UnityEngine;

namespace Pets
{
    public class PetScript : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private PetScrubBase information;
        private String petName;
        private Sprite petSprite;
        private int growthStage; //0 is egg, 1 is kid, 2 is adult
        private int creatureType; //0 is blob, 1 is lilma, 2 is dragon
    
        private int love;
        private int clean;
        private int hunger;
        private int sleepy;
    
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = information.petSprite;
        }

        public void ChangeSprite(Sprite newSprite)
        {
            _spriteRenderer.sprite = newSprite;
            information.petSprite = newSprite;
        }
    }
}
