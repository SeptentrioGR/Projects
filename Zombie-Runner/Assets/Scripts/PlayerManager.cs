using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

public class PlayerManager{

    public static PlayerManager m_Instance;
    private Character Player;

    public static PlayerManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public void Initialize()
    {
        m_Instance = this;
        Player = PrefabManager.Instance.m_Player;
    }

    public Character GetPlayer()
    {
        return Player;
    }   
}
