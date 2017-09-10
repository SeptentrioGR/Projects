using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun {
    public class RadioClearArea : MonoBehaviour {

        private static RadioClearArea m_Instance;
        private bool m_AreaIsClear;
        public float m_TimeSinceLastTrigger = 0f;

        //----------------------------------------------------------------------------------------------------
        public bool AreaIsClear {
            get
            {
                return m_AreaIsClear;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public static RadioClearArea Instance
        {
            get
            {
                return m_Instance;
            }
        }

        //----------------------------------------------------------------------------------------------------
        void Awake() {
            m_Instance = this;
        }

        //----------------------------------------------------------------------------------------------------
        void LateUpdate() {
            var player = PlayerManager.Instance.GetPlayer();
            transform.position = player.transform.position;
            m_TimeSinceLastTrigger += Time.deltaTime;
        }

        //----------------------------------------------------------------------------------------------------
        void OnTriggerStay(Collider collider)
        {
            if (collider.tag != "Player")
            {
                m_TimeSinceLastTrigger = 0f;
                m_AreaIsClear = false;
            }
        }

        //----------------------------------------------------------------------------------------------------
        void OnTriggerExit(Collider other)
        {
            if (other.tag != "Player")
            {
                m_AreaIsClear = true;
            }
        }
    }
}
