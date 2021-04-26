using DataContainers;
using UnityEngine;

namespace Pets
{
    public class AgeUp : MonoBehaviour
    {
        [SerializeField] private GameObject thePet;
        private Animator _animator;
        [SerializeField] private PetScript petScript;
        [SerializeField] private PetScrubBase petScrub;
        [SerializeField] private SpriteList spriteList;

        private void Start()
        {
            _animator = thePet.GetComponent<Animator>();
        }

        public void AgeUpButton()
        {
            petScrub.growthStage++;

            _animator.SetTrigger(0);
            
            if (petScrub.growthStage == 1)
            {
                switch (petScrub.creatureType)
                {
                    case 0:
                        petScrub.petSprite = spriteList.mochiKid;
                        break;
                    case 1:
                        petScrub.petSprite = spriteList.lilmaKid;
                        break;
                    case 2:
                        petScrub.petSprite = spriteList.nyodleKid;
                        break;
                    default:
                        print("growth stage kid, no sprite");
                        break;
                }
            }
            else if(petScrub.growthStage == 2)
            {
                switch (petScrub.creatureType)
                {
                    case 0:
                        petScrub.petSprite = spriteList.mochiAdult;
                        break;
                    case 1:
                        petScrub.petSprite = spriteList.lilmaAdult;
                        break;
                    case 2:
                        petScrub.petSprite = spriteList.nyodleAdult;
                        break;
                    default:
                        print("growth stage adult, no sprite");
                        break;
                }
            }
            
            petScript.Start();
        }
    }
}
