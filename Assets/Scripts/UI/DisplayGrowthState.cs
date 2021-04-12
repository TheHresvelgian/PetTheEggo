using DataContainers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DisplayGrowthState : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private PetScrubBase pet;

        private void Awake()
        {
            switch (pet.growthStage)
            {
                case 0:
                    text.text = "Baby";
                    break;
                case 1:
                    text.text = "Kid";
                    break;
                case 2:
                    text.text = "Adult";
                    break;
                default:
                    text.text = "??";
                    break;
            }
        }
    }
}
