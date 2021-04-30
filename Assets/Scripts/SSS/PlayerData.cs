using System;

namespace SSS
{
    [Serializable]
    public class PlayerData
    {
        /*public PetScrubBase pet1;
        public PetScrubBase pet2;
        public PetScrubBase pet3;*/

        //public PetScrubBase[] pets;

        public String[] names;
        public int[] growthStages;
        public int[] creatureTypes;

        public int[] loves;
        public int[] cleans;
        public int[] hungers;
        public int[] sleepies;
        public int[] growthPercentages;
        public int[] leavePercentages;

        public int[] playerInventory;
        public int[] shopInventory;
        
        
        public PlayerData(Save theData)
        {
            names = new String[3];
            growthStages = new int[3];
            creatureTypes = new int[3];
            
            loves = new int[3];
            cleans = new int[3];
            hungers = new int[3];
            sleepies = new int[3];
            growthPercentages = new int[3];
            leavePercentages = new int[3];

            playerInventory = new int[12];

            names[0] = theData.savePet1.petName;
            names[1] = theData.savePet2.petName;
            names[2] = theData.savePet3.petName;

            growthStages[0] = theData.savePet1.growthStage;
            growthStages[1] = theData.savePet2.growthStage;
            growthStages[2] = theData.savePet3.growthStage;

            creatureTypes[0] = theData.savePet1.creatureType;
            creatureTypes[1] = theData.savePet2.creatureType;
            creatureTypes[2] = theData.savePet3.creatureType;

            loves[0] = theData.savePet1.love;
            loves[1] = theData.savePet2.love;
            loves[2] = theData.savePet3.love;

            cleans[0] = theData.savePet1.clean;
            cleans[1] = theData.savePet2.clean;
            cleans[2] = theData.savePet3.clean;

            hungers[0] = theData.savePet1.hunger;
            hungers[1] = theData.savePet2.hunger;
            hungers[2] = theData.savePet3.hunger;

            sleepies[0] = theData.savePet1.sleepy;
            sleepies[1] = theData.savePet2.sleepy;
            sleepies[2] = theData.savePet3.sleepy;

            growthPercentages[0] = theData.savePet1.growthPercent;
            growthPercentages[1] = theData.savePet2.growthPercent;
            growthPercentages[2] = theData.savePet3.growthPercent;

            leavePercentages[0] = theData.savePet1.leavePercent;
            leavePercentages[1] = theData.savePet2.leavePercent;
            leavePercentages[2] = theData.savePet3.leavePercent;

            playerInventory[0] = theData.playerInventory.Container[0].amount;
            playerInventory[1] = theData.playerInventory.Container[1].amount;
            playerInventory[2] = theData.playerInventory.Container[2].amount;
            playerInventory[3] = theData.playerInventory.Container[3].amount;
            playerInventory[4] = theData.playerInventory.Container[4].amount;
            playerInventory[5] = theData.playerInventory.Container[5].amount;
            playerInventory[6] = theData.playerInventory.Container[6].amount;
            playerInventory[7] = theData.playerInventory.Container[7].amount;
            playerInventory[8] = theData.playerInventory.Container[8].amount;
            playerInventory[9] = theData.playerInventory.Container[9].amount;
            playerInventory[10] = theData.playerInventory.Container[10].amount;
            playerInventory[11] = theData.playerInventory.Container[11].amount;

            shopInventory[0] = theData.shopInventory.Container[0].amount;
            shopInventory[1] = theData.shopInventory.Container[1].amount;
            shopInventory[2] = theData.shopInventory.Container[2].amount;
        }
    }
}
