using System.Collections;
using System.IO;
using DataContainers;
using UnityEngine;

namespace SSS
{
    public class Save : MonoBehaviour
    {

        public PetScrubBase savePet1;
        public PetScrubBase savePet2;
        public PetScrubBase savePet3;

        public InventoryObject playerInventory;
        public InventoryObject shopInventory;
        
        
        public void SavePlayer()
        {
            SaveStateSystem.SavePlayer(this);
        }

        public void SaveNQuit()
        {
            SaveStateSystem.SavePlayer(this);
            StartCoroutine(nameof(Close));
        }

        private IEnumerator Close()
        {
            yield return new WaitForSeconds(3f);
            Application.Quit();
        }
        
        public void DeleteSaveData()
        {
            File.Delete(SaveStateSystem._dataPath);
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

            savePet1.growthPercent = data.growthPercentages[0];
            savePet2.growthPercent = data.growthPercentages[1];
            savePet3.growthPercent = data.growthPercentages[2];

            savePet1.leavePercent = data.leavePercentages[0];
            savePet2.leavePercent = data.leavePercentages[1];
            savePet3.leavePercent = data.leavePercentages[2];

            playerInventory.Container[0].amount = data.playerInventory[0];
            playerInventory.Container[1].amount = data.playerInventory[1];
            playerInventory.Container[2].amount = data.playerInventory[2];
            playerInventory.Container[3].amount = data.playerInventory[3];
            playerInventory.Container[4].amount = data.playerInventory[4];
            playerInventory.Container[5].amount = data.playerInventory[5];
            playerInventory.Container[6].amount = data.playerInventory[6];
            playerInventory.Container[7].amount = data.playerInventory[7];
            playerInventory.Container[8].amount = data.playerInventory[8];
            playerInventory.Container[9].amount = data.playerInventory[9];

            shopInventory.Container[0].amount = data.shopInventory[0];
            shopInventory.Container[1].amount = data.shopInventory[1];
            shopInventory.Container[2].amount = data.shopInventory[2];
        }
    }
}
