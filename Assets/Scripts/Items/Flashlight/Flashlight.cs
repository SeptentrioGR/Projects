
using System;
using UnityEngine;
namespace ZombieRun
{
    [Serializable]
    public class Flashlight
    {

        public GameObject lightsource;
        private float startingBattery;
        private float currentBattery;
        public float mBatteryThreshold;
        public BasicLightFlickering mBasicLightFlickering;

        public float GetBatteryLevelInPresentage()
        {
            return currentBattery / startingBattery;
        }

        public float GetBatteryLevel()
        {
            return currentBattery;
        }

        public void Initialize(float startingBattery)
        {
            this.startingBattery = startingBattery;
            currentBattery = startingBattery;
            mBasicLightFlickering = new BasicLightFlickering();
            mBasicLightFlickering.Initialize(lightsource.GetComponent<Light>(),0.5f,1,0.2f);

        }

        public void Update()
        {
            if (LightIsPowered())
            {
                currentBattery -= mBatteryThreshold * Time.deltaTime;
            }
            else
            {
                currentBattery += mBatteryThreshold * Time.deltaTime;
            }

            if (currentBattery <= 0 && LightIsPowered())
            {
                Power();
            }

            currentBattery = Mathf.Clamp(currentBattery, 0, startingBattery);

            if (currentBattery < 25f)
            {
                mBasicLightFlickering.Active = true;
            }
            else
            {
                mBasicLightFlickering.Active = false;
                mBasicLightFlickering.Reset();
            }

            mBasicLightFlickering.Update();
        }

        public void Power()
        {
            lightsource.GetComponent<Light>().enabled = !lightsource.GetComponent<Light>().enabled;
        }

        public void InsertBattery()
        {
            currentBattery = startingBattery;
        }

        public bool LightIsPowered()
        {
            return lightsource.GetComponent<Light>().enabled;
        }

    }
}
