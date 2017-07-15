using UnityEngine;
using UnityEngine.UI;

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
        Character m_Player = PlayerManager.Instance.GetPlayer();
        switch (status)
        {
            case StatusType.Health:
                m_Value = m_Player.mHealth;
                break;
            case StatusType.Stamina:
                m_Value = m_Player.mStamina;
                break;
            case StatusType.Sanity:
                m_Value = m_Player.mSanity;
                break;
                //case StatusType.Hunger:
                //    value = m_ps.s_system.checkHunger();
                //    break;
                //case StatusType.Thirst:
                //    value = m_ps.s_system.checkThirst();
                //    break;
        }

    }
}