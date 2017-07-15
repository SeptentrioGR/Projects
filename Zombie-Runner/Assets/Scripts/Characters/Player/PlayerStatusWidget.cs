using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusWidget : MonoBehaviour
{
    private static PlayerStatusWidget m_Instance;

    public static PlayerStatusWidget Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public enum StatusType
    {
        Health, Sanity, Stamina, Hunger, Thirst
    }

    public StatusType status;

    public Text StatusName;
    private Slider StatusSlider;
    private float value;
    private Character m_Player;

    void Start()
    {
        m_Player = PlayerManager.Instance.GetPlayer();
        StatusSlider = GetComponent<Slider>();
        switch (status)
        {
            case StatusType.Health:
                StatusName.text = "HEALTH";
                break;
            case StatusType.Stamina:
                StatusName.text = "STAMINA";
                break;
            case StatusType.Sanity:
                StatusName.text = "SANITY";
                break;
            //case StatusType.Hunger:
            //    StatusName.text = "HUNGER";
            //    break;
            //case StatusType.Thirst:
            //    StatusName.text = "THIRST";
            //    break;
        }
    }


    void RefreshSliders()
    {
        StatusSlider.value = value;
        StatusUpdate();

    }

    void StatusUpdate()
    {
        switch (status)
        {
            case StatusType.Health:
                value = m_Player.mHealth;
                break;
            case StatusType.Stamina:
                value = m_Player.mStamina;
                break;
            case StatusType.Sanity:
                value = m_Player.mSanity;
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
