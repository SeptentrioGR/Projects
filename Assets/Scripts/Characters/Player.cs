using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Water;
using System;
using System.Collections.Generic;
namespace ZombieRun
{

    public class Player : Character
    {
        public float mSanity = 100;

        public Flashlight m_Flashlight;

        //private FirstPersonController controller;
        private CharacterController c_controller;
        private bool UpdateHoldingItems;

        public Item[] Items;
        private Dictionary<string, GameObject> UsableItems = new Dictionary<string, GameObject>();
        private int itemInUse;

        private float m_TimeSinceRun = 0;
        private bool Rested = true;


        public BasicHeartSoundBasedOnValue mHeartBeatingSound;

        //public FirstPersonController getPlayerController()
        //{
        //    return controller;
        //}

        // Use this for initialization
        void Start()
        {
            Health = 100;
            Stamina = 100;
            damage = 25;
            attackRate = 0.3f;
            //controller = GetComponent<FirstPersonController>();
            c_controller = GetComponent<CharacterController>();
            //controller.enabled = true;
            //c_controller.enabled = true;
            m_Flashlight.Initialize(100);
            m_StartingTransform = transform.position;
            m_StartingRotation = Quaternion.identity;
            mHeartBeatingSound.Initialize(GetComponent<AudioSource>());
            InstansiateItems();
        }

        public void Reset()
        {
            UpdateHoldingItems = true;
            transform.rotation = m_StartingRotation;
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
            HealthSystem();
            StaminaSystem();

            m_Flashlight.Update();
            mHeartBeatingSound.Update(Health);


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

        //----------------------------------------------------------------------------------------------------
        private void ShowItemToUse(string name)
        {
            GameObject go;
            UsableItems.TryGetValue(name, out go);
            go.SetActive(true);
        }

        //----------------------------------------------------------------------------------------------------
        public override void Death()
        {
            if (m_Flashlight.LightIsPowered())
            {
                m_Flashlight.Power();
            }
        }

        //----------------------------------------------------------------------------------------------------
        public override void StaminaSystem()
        {
            if (!Rested)
            {
                m_TimeSinceRun-= Time.deltaTime;
                m_TimeSinceRun = Mathf.Clamp(m_TimeSinceRun, 0, 2);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Stamina -= RunningThreshold;
                m_TimeSinceRun = 2;
            }
            else
            {
                Stamina += .5f;
            }

            if (Stamina <= 0)
            {
                Rested = false;
                //controller.WalkingSpeed = 2.5f;
                //controller.RunningSpeed = 3.5f;
            }
            else if (Stamina > 0 && Rested)
            {
                //controller.WalkingSpeed = 5f;
                //controller.RunningSpeed = 10f;
            }

            if (m_TimeSinceRun <= 0)
            {
                Rested = true;
            }

            Stamina = Mathf.Clamp(Stamina, 0, 100);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(0, 256, 512, 64), String.Format("Rested:{0}", Rested));
            GUI.Label(new Rect(0, 512, 512, 64), String.Format("Time Since Run:{0}", m_TimeSinceRun));
        }

    }
}
