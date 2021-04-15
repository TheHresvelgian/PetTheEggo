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
                        petScrub.petSprite = SpriteList.mochiKid;
                        break;
                    case 1:
                        petScrub.petSprite = SpriteList.lilmaKid;
                        break;
                    case 2:
                        petScrub.petSprite = SpriteList.nyodleKid;
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
                        petScrub.petSprite = SpriteList.mochiAdult;
                        break;
                    case 1:
                        petScrub.petSprite = SpriteList.lilmaAdult;
                        break;
                    case 2:
                        petScrub.petSprite = SpriteList.nyodleAdult;
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
