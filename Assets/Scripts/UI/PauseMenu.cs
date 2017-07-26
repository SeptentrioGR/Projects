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
            GuiManager.Instance.AssingActionToButton(ButtonAction.Resume, m_ResumeButton);
            GuiManager.Instance.AssingActionToButton(ButtonAction.Back, m_QuitButton);
        }

        public void Exit()
        {
            SceneManager.LoadScene(0);
        }
        public void Resume()
        {
            GameManager.Instance.TogglePause();
        }
    }
}
