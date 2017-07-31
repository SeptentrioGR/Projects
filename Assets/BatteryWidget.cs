using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
{
    public class BatteryWidget : MonoBehaviour
    {
        public RawImage mRawImage;
        [Range(0,100)]
        public float value;
        public float batteryLevel;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            batteryLevel = PlayerManager.Instance.GetPlayer().GetComponent<Player>().m_Flashlight.GetBatteryLevel();
            float HealthAsPretentage = PlayerManager.Instance.GetPlayer().GetComponent<Player>().m_Flashlight.GetBatteryLevelInPresentage();
            value = (HealthAsPretentage/ 2f);
            mRawImage.uvRect = new Rect(0f, value, 0.5f, .5f);
        }
    }
}
