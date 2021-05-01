using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace DataContainers
{
    [CreateAssetMenu]
    public class PetScrubBase : ScriptableObject
    {
        [Header("Identifiers")]
        public String petName;
        public Sprite petSprite;
        public int growthStage; //0 is egg, 1 is kid, 2 is adult
        public int creatureType; //0 is blob, 1 is Lilma, 2 is dragon

        [Header("Stats")] 
        public int love;
        public int clean;
        public int hunger;
        public int sleepy;
        public int growthPercent;
        public int leavePercent;

        public void ResetPet()
        {
            petName = null;
            petSprite = null;
            growthStage = 0;

            love = 0;
            clean = 100;
            hunger = 50;
            sleepy = 50;
            growthPercent = 0;
            leavePercent = 0;
        }
    }
}
