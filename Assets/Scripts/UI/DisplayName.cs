using DataContainers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DisplayName : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private PetScrubBase pet;

        private void Awake()
        {
            text.text = pet.petName;
        }
    }
}
