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
    public PlayerStatusWidgetItem[] m_PlayerStatusWidgetItem;
   
    private Character m_Player = null;

    private void Awake()
    {
        m_Instance = this;
    }

    public void Initialize()
    {
        foreach (PlayerStatusWidgetItem item in m_PlayerStatusWidgetItem)
        {
            item.Initialize();
        }
    }

    public void RefreshContent()
    {
        foreach (PlayerStatusWidgetItem item in m_PlayerStatusWidgetItem)
        {
            item.RefreshContent();
        }
    }
}
