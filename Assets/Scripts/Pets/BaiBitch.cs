using DataContainers;
using UnityEngine;

namespace Pets
{
    public class BaiBitch : MonoBehaviour
    {
        [SerializeField] private GameObject thePet;
        [SerializeField] private PetScript petScript;
        [SerializeField] private PetScrubBase petScrubBase;
        [SerializeField] private GameObject baiButton;
        [SerializeField] private SpriteList spriteList;

        public void Leave()
        {
            petScrubBase.ResetPet();
            petScript._spriteRenderer.sprite = spriteList.letter;
            petScrubBase.petSprite = spriteList.letter;
            baiButton.SetActive(true);
        }

        public void BaiButton()
        {
            petScript._spriteRenderer.sprite = spriteList.basket;
            petScrubBase.petSprite = spriteList.basket;
        }
    }
}