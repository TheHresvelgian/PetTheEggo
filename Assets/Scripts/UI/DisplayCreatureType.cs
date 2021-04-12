using DataContainers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DisplayCreatureType : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private PetScrubBase pet;

        private void Awake()
        {
            switch (pet.creatureType)
            {
                case 0:
                    text.text = "Blob";
                    break;
                case 1:
                    text.text = "Lilma";
                    break;
                case 2:
                    text.text = "Dragon";
                    break;
                default:
                    text.text = "??";
                    break;
            }
        }
    }
}
