using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
{

    public class PlayerStatusWidgetItem : MonoBehaviour
    {

        public enum StatusType
        {
            Health, Sanity, Stamina, Hunger, Thirst
        }

        public StatusType status;

        public float m_Value;
        public Slider m_Slider;



        public void Initialize()
        {

        }


        public void RefreshContent()
        {
            m_Slider.value = m_Value;
            StatusUpdate();

        }

        void StatusUpdate()
        {
            var player = PlayerManager.Instance.GetPlayer();
            switch (status)
            {
                case StatusType.Health:
                    m_Value = player.Health;
                    break;
                case StatusType.Stamina:
                    m_Value = player.Stamina;
                    break;
                case StatusType.Sanity:
                    m_Value = player.GetComponent<Player>().mSanity;
                    break;
            }

        }
    }
}