using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinningPanel : MonoBehaviour {

    public Button m_PlayAgain;
    public Button m_QuitButton;

    void Start () {
        GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Back, m_QuitButton);
        GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Reset, m_PlayAgain);
    }
	
}
