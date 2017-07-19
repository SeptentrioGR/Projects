using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

public class PlayerManager {

    public static PlayerManager m_Instance;
    private Character Player;

    public PlayerManager()
    {
        Debug.Log("Player Initialization");
        m_Instance = this;
        Player = PrefabManager.Instance.m_Player;
    }

    public static PlayerManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public Character GetPlayer()
    {
        return Player;
    }   
}
