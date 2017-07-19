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
            m_ResumeButton.onClick.AddListener(Resume);
            m_QuitButton.onClick.AddListener(Exit);
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
