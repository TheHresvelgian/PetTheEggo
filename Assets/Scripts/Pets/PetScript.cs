using System;
using System.Collections;
using DataContainers;
using UnityEngine;

namespace Pets
{
    public class PetScript : MonoBehaviour
    {
        public SpriteRenderer _spriteRenderer;
        [SerializeField] private InventoryObject playerInv;
        [SerializeField] private ItemObjects egg;
        public bool _play;
        [SerializeField] public PetScrubBase information;
        [SerializeField] private BaiBitch baiBitch;
        
        private String _petName;
        private int _growthStage; //0 is egg, 1 is kid, 2 is adult
        private int _creatureType; //0 is blob, 1 is lilma, 2 is dragon

        private Sprite _sprite;
        public SpriteList spriteList;
        public SpriteList normal;
        public SpriteList happy;
        public SpriteList pleased;
    
        private int _love;
        private int _isLoving; //-1 is bad (20 or less), 0 is normal (21-50), +1 is good (51-80), +2 is awesome (81-100)

        private int _clean;
        private int _isClean; //-1 is bad (20 or less), 0 is normal (21-50), +1 is good (51-80), +2 is awesome (81-100)

        private int _hunger;
        private int _isFull; //-1 is bad (20 or less), 0 is normal (21-50), +1 is good (51-80), +2 is awesome (81-100)

        private int _sleepy;
        private int _isRested; //-1 is bad (20 or less), 0 is normal (21-50), +1 is good (51-80), +2 is awesome (81-100)

        private int _growthPercent;
        private int _leavePercent;

        public float pingTime = 60f;
        private float _timer;

        [SerializeField] private int hatchPercent;
        [SerializeField] private GameObject hatchButton;

        [SerializeField] private int transformPercent;
        [SerializeField] private GameObject transformButton;
    
        public void Start()
        {
            if (spriteList == null)
            {
                spriteList = normal;
            }
            _spriteRenderer = GetComponent<SpriteRenderer>();

            baiBitch = GetComponent<BaiBitch>();
            _play = false;
            for (int i = 0; i < playerInv.Container.Count; i++)
            {
                if (playerInv.Container[i].item == egg && playerInv.Container[i].amount != 0)
                {
                    _play = true;
                    break;
                }
            }
            if (!_play)
            {
                _spriteRenderer.sprite = spriteList.basket;
                return;
            }
            if (information.creatureType == 0)
            {
                switch (information.growthStage)
                {
                    case 0:
                        _sprite = spriteList.mochiEgg;
                        break;
                    case 1:
                        _sprite = spriteList.mochiKid;
                        break;
                    case 2:
                        _sprite = spriteList.mochiAdult;
                        break;
                    default:
                        print("fuck");
                        break;
                }
            }
            else if (information.creatureType == 1)
            {
                switch (information.growthStage)
                {
                    case 0:
                        _sprite = spriteList.lilmaEgg;
                        break;
                    case 1:
                        _sprite = spriteList.lilmaKid;
                        break;
                    case 2:
                        _sprite = spriteList.lilmaAdult;
                        break;
                    default:
                        print("fuck");
                        break;
                }
            }
            else if (information.creatureType == 2)
            {
                switch (information.growthStage)
                {
                    case 0:
                        _sprite = spriteList.nyodleEgg;
                        break;
                    case 1:
                        _sprite = spriteList.nyodleKid;
                        break;
                    case 2:
                        _sprite = spriteList.nyodleAdult;
                        break;
                    default:
                        print("fuck");
                        break;
                }
            }

            information.petSprite = _sprite;

            _spriteRenderer.sprite = information.petSprite;

            _love = information.love;

            _hunger = information.hunger;

            _clean = information.clean;

            _sleepy = information.sleepy;

            _petName = information.petName;

            _growthStage = information.growthStage;

            _creatureType = information.creatureType;

            _growthPercent = information.growthPercent;

            _leavePercent = information.leavePercent;

        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= pingTime)
            {
                _timer = 0;
                StartCoroutine(nameof(WasPinged));
            }

            if (_love >= 81)
            {
                _isLoving = 2;
            }
            else if (_love >= 51)
            {
                _isLoving = 1;
            }
            else if (_love >= 21)
            {
                _isLoving = 0;
            }
            else
            {
                _isLoving = -1;
            }
            
            if (_clean >= 81)
            {
                _isClean = 2;
            }
            else if (_clean >= 51)
            {
                _isClean = 1;
            }
            else if (_clean >= 21)
            {
                _isClean = 0;
            }
            else
            {
                _isClean = -1;
            }
            
            if (_hunger >= 81)
            {
                _isFull = 2;
            }
            else if (_hunger >= 51)
            {
                _isFull = 1;
            }
            else if (_hunger >= 21)
            {
                _isFull = 0;
            }
            else
            {
                _isFull = -1;
            }
            
            if (_sleepy >= 81)
            {
                _isRested = 2;
            }
            else if (_sleepy >= 51)
            {
                _isRested = 1;
            }
            else if (_sleepy >= 21)
            {
                _isRested = 0;
            }
            else
            {
                _isRested = -1;
            }

            if (_growthPercent >= hatchPercent && _growthStage == 0)
            {
                hatchButton.SetActive(true);
            }
            else if (_growthPercent >= transformPercent && _growthStage == 1)
            {
                transformButton.SetActive(true);
            }
            else
            {
                transformButton.SetActive(false);
                hatchButton.SetActive(false);
            }

            if (_leavePercent >= 100)
            {
                baiBitch.Leave();
            }

        }

        public void ChangeSprite(Sprite newSprite)
        {
            _spriteRenderer.sprite = newSprite;
            information.petSprite = newSprite;
        }
        
        private IEnumerator WasPinged()
        {
            int total = _isClean + _isFull + _isLoving + _isRested;
            if (_isLoving > -1 && _isClean > -1 && _isFull > -1 && _isRested > -1)
            {
                if (total == 8)
                {
                    _growthPercent += 4;
                    _leavePercent--;
                }

                else if (total >= 6)
                {
                    _growthPercent += 3;
                }
                else if (total >= 4)
                {
                    _growthPercent += 2;
                }
                else if (total >= 2)
                {
                    _growthPercent += 1;
                }
                else
                {
                    yield return null;
                }
            }
            _clean--;
            _sleepy--;
            _hunger--;

            if (_isClean + _isFull + _isRested <= 0)
            {
                _love--;
                _leavePercent++;
            }

            information.clean = _clean;
            information.love = _love;
            information.hunger = _hunger;
            information.sleepy = _sleepy;
            information.growthPercent = _growthPercent;
        }
    }
}
