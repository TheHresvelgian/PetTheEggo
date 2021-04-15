using System;
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
    }
}
