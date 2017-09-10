using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
    public abstract class ToggleByDistance : MonoBehaviour
    {
        public float mMaxDistance;
        public float distance;
        [HideInInspector]
        public bool Toggle;

        public void CheckForDistance()
        {
            distance = GetComponentInParent<MonsterAI>().distance;
            if (distance < mMaxDistance )
            {
                Toggle = true;
            }
            else if (distance > mMaxDistance)
            {
                Toggle = false;
            }
        }

    }

}
