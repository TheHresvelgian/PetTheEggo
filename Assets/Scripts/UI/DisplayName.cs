using DataContainers;
using Pets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DisplayName : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject creatures;
        [SerializeField] private PetScrubBase pet;

        public void Awake() =>
        text.text = creatures.GetComponent<CreatureController>().selectedPet.GetComponent<PetScript>().information.petName;
    }
}
