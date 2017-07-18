using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class GameOverState : State
    {
        public override void Update()
        {
            PrefabManager.Instance.m_ListOfPrefabs[3].SetActive(true);
        }
    }

}
