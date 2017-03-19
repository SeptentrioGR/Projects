using UnityEngine;
using UnityEngine.UI;

public class Player_Status : MonoBehaviour
{
    public enum StatusType
    {
        Health, Sanity, Stamina, Hunger, Thirst
    }
    public StatusType status;
    public Text StatusName;
    public Image StatusTexture;
    public Slider StatusSlider;
    public float value;
    public PlayerScript m_ps;
    void Start()
    {
        m_ps = GameObject.FindObjectOfType<PlayerScript>();
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
            case StatusType.Hunger:
                StatusName.text = "HUNGER";
                break;
            case StatusType.Thirst:
                StatusName.text = "THIRST";
                break;
        }
    }


    void Update()
    {
        StatusSlider.value = value;
        StatusUpdate();

    }

    void StatusUpdate()
    {
        switch (status)
        {
            case StatusType.Health:
                value = m_ps.mHealth;
                break;
            case StatusType.Stamina:
                value = m_ps.mStamina;
                break;
            case StatusType.Sanity:
                value = m_ps.mSanity;
                break;
            case StatusType.Hunger:
                value = m_ps.s_system.checkHunger();
                break;
            case StatusType.Thirst:
                value = m_ps.s_system.checkThirst();
                break;
        }


    }


}
