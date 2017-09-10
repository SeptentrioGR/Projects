using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
{
    public class SimpleCursorChange : MonoBehaviour
    {

        public Sprite m_Sprite;

        public void ChangeCursorToInteraction()
        {
            CameraManager.Instance.SetIcon(m_Sprite);
        }

    }
}
