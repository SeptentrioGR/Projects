using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class GameOver : MonoBehaviour
    {
        public void Update()
        {
            PrefabManager.Instance.m_ListOfPrefabs[3].SetActive(true);
        }
    }

}
