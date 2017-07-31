using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZombieRun
{
    public class PauseMenu : MonoBehaviour
    {
        public Button m_ResumeButton;
        public Button m_QuitButton;

        void Start()
        {
            GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Back, m_QuitButton);
            GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Resume, m_ResumeButton);
        }
    }
}
