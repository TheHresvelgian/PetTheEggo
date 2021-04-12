using DataContainers;
using UnityEngine;

namespace SSS
{
    public class Save : MonoBehaviour
    {

        public PetScrubBase savePet1;
        public PetScrubBase savePet2;
        public PetScrubBase savePet3;
        
        
        public void SavePlayer()
        {
            SaveStateSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveStateSystem.LoadPlayer();

            savePet1.petName = data.names[0];
            savePet2.petName = data.names[1];
            savePet3.petName = data.names[2];

            savePet1.growthStage = data.growthStages[0];
            savePet2.growthStage = data.growthStages[1];
            savePet3.growthStage = data.growthStages[2];

            savePet1.creatureType = data.creatureTypes[0];
            savePet2.creatureType = data.creatureTypes[1];
            savePet3.creatureType = data.creatureTypes[2];

            savePet1.love = data.loves[0];
            savePet2.love = data.loves[1];
            savePet3.love = data.loves[2];

            savePet1.clean = data.cleans[0];
            savePet2.clean = data.cleans[1];
            savePet3.clean = data.cleans[2];

            savePet1.hunger = data.hungers[0];
            savePet2.hunger = data.hungers[1];
            savePet3.hunger = data.hungers[2];

            savePet1.sleepy = data.sleepies[0];
            savePet2.sleepy = data.sleepies[1];
            savePet3.sleepy = data.sleepies[2];

        }
    }
}
