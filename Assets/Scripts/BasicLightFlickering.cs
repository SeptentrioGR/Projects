using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class BasicLightFlickering
    {
        public Light mLight;
        public float minIntensity;
        public float maxIntensity;

        private float nextActionTime = 0.0f;
        public float period = 0.1f;
        private float lightIntensity;

        private bool mActive = false;
        public bool Active
        {
            get
            {
                return mActive;
            }
            set
            {
                mActive = value;
            }
        }

        public void Initialize(Light light,float min,float max,float period)
        {
            mLight = light;
            minIntensity = min;
            maxIntensity = max;
            this.period = period;
        }

        public void Reset()
        {
            mLight.intensity = 1;
        }

        public void Update()
        {
            if (mActive)
            {
                float lightIntensity = mLight.intensity;
                var xVar = Random.Range(minIntensity, maxIntensity);
                var yVar = Random.Range(minIntensity, maxIntensity);
                if (Time.time > nextActionTime)
                {
                    nextActionTime += period;
                    lightIntensity = Mathf.Lerp(xVar, yVar, Time.deltaTime);
                }

                mLight.intensity = lightIntensity;
            }

        }
    }
}
