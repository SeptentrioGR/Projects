using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Water;
using System;
using System.Collections.Generic;
namespace ZombieRun
{

    public class Player : Character
    {
        public float mSanity = 100;

        public Flashlight m_Flashlight;

        private FirstPersonController controller;
        private CharacterController c_controller;
        private int HoldingItem = 0;
        private bool UpdateHoldingItems;

        public Item[] Items;
        private Dictionary<string, GameObject> UsableItems = new Dictionary<string, GameObject>();
        private int itemInUse;

        public BasicHeartSoundBasedOnValue mHeartBeatingSound;

        public FirstPersonController getPlayerController()
        {
            return controller;
        }

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<FirstPersonController>();
            c_controller = GetComponent<CharacterController>();
            controller.enabled = true;
            c_controller.enabled = true;
            m_Flashlight.Initialize(100);
            StartingTransform = transform.position;
            StartingRotation = Quaternion.identity;
            mHeartBeatingSound.Initialize(GetComponent<AudioSource>());

            InstansiateItems();
        }

        public void Reset()
        {
            HoldingItem = 0;
            UpdateHoldingItems = true;
            transform.rotation = StartingRotation;
        }

        public void UpdateUsbleItems()
        {
            foreach (GameObject item in UsableItems.Values)
            {
                item.SetActive(false);
            }
        }

        private void InstansiateItems()
        {
            foreach (Item ui in Items)
            {
                var itemPrefab = ui.getItemPrefab();
                var item = Instantiate(itemPrefab, Hand);
                item.transform.localPosition = ui.getItemGrip().localPosition;
                item.transform.localRotation = ui.getItemGrip().localRotation;
                UsableItems.Add(ui.name, item);
            }
            UpdateUsbleItems();
        }

        // Update is called once per frame
        void Update()
        {
            m_Flashlight.Update();
            mHeartBeatingSound.Update(ref mHealth);


            if (itemInUse == 0)
            {
                UpdateUsbleItems();
            }
            if (itemInUse == 1)
            {
                ShowItemToUse(Items[0].name);
            }
            if (itemInUse == 2)
            {
                ShowItemToUse(Items[1].name);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (m_Flashlight.LightIsPowered())
                {
                    m_Flashlight.Power();
                    itemInUse = 0;
                }
                else
                {
                    itemInUse = 1;
                }
                UpdateHoldingItems = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && InventoryManager.Instance.HasItem("Radio"))
            {
                itemInUse = 2;
                if (m_Flashlight.LightIsPowered())
                {
                    m_Flashlight.Power();
                }
                UpdateHoldingItems = true;
            }


            if (UpdateHoldingItems)
            {
                UpdateHoldingItems = false;
                switch (itemInUse)
                {
                    case 0:
                        break;
                    case 1:
                        m_Flashlight.Power();
                        UpdateUsbleItems();
                        break;
                    case 2:
                        UpdateUsbleItems();
                        break;
                }
            }

        }

        private void ShowItemToUse(string name)
        {
            GameObject go;
            UsableItems.TryGetValue(name, out go);
            go.SetActive(true);
        }

        public override void Death()
        {
            if (m_Flashlight.LightIsPowered())
            {
                m_Flashlight.Power();
            }
        }


        public override void StaminaSystem()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                mStamina -= decreaseWhileRun;
            }
            else
            {
                mStamina += 1f;
            }

            if (mStamina <= 0)
            {
                controller.DisableRun(false);
            }
            else
            {
                controller.DisableRun(true);
            }

            mStamina = Mathf.Clamp(mStamina, 0, 100);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Water>())
            {
                UnderWater = !UnderWater;
            }
        }
    }
}
