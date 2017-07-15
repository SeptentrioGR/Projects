using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace ZombieRun
{
	public class GUIButtons : MonoBehaviour {


		public void PlayGame()
		{
            GameManager.Instance.SetState(GameStates.Game);
			SceneManager.LoadScene(1);
		}

		public void ExitGame()
		{
			Application.Quit();
		}

		public void LoadMenu()
		{
            GameManager.Instance.SetState(GameStates.Menu);
            SceneManager.LoadScene(0);
		}

		public void ResetGame()
		{
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene(1);
		}



	}
}
