using DataContainers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatSliderScript : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private PetScrubBase pet;
        [SerializeField] private int whichStat;

        private void Update()
        {
            switch (whichStat)
            {
                case 0:
                    SetStat(pet.love);
                    break;
                case 1:
                    SetStat(pet.clean);
                    break;
                case 2:
                    SetStat(pet.hunger);
                    break;
                case 3:
                    SetStat(pet.sleepy);
                    break;
                default:
                    print("No stat selected");
                    break;
            }
        }

        public void SetStat(int stat)
        {
            slider.value = stat;
        }
    }
}
