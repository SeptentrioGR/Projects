using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace ZombieRun
{
	public class Game : MonoBehaviour {

		private static Game m_Instance;
		private GameObject Player;
		private EnemyManager enemyManager;
		private bool GameFinished = false;
		public GameObject Map;
		public static Game Instance
		{
			get
			{
				return m_Instance;
			}
		}

		void Start() {
			m_Instance = this;
			enemyManager = GameObject.FindObjectOfType<EnemyManager>();
			Player = GameObject.Find("Player");
			GameManager.Instance.ResetGame();
			Map.SetActive(false);
		}

		// Update is called once per frame
		void Update() {
			if (!GameFinished)
			{
				if (GameManager.Instance.CheckIfPaused())
				{
					UIManager.mInstance.Panels[UIManager.PanelElements.Pause].SetActive(true);
				}
				else if (!GameManager.Instance.CheckIfPaused())
				{
					UIManager.mInstance.Panels[UIManager.PanelElements.Pause].SetActive(false);
				}

				if (Cursor.lockState == CursorLockMode.Locked)
				{
					Player.GetComponent<FirstPersonController>().enabled = true;
				}
				else if (Cursor.lockState == CursorLockMode.None)
				{
					Player.GetComponent<FirstPersonController>().enabled = false;
				}

				if (UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled)
				{
					Player.GetComponent<PlayerScript>().IAquireRadio();
				}

				enemyManager.Spawn();

				UIManager.mInstance.ChangeIconColor(Color.black);
				if (RadioClearArea.Instance.ClearArea)
				{
					//Debug.Log("Clear Area");
					UIManager.mInstance.ChangeIconColor(Color.green);
				}

				if (Input.GetKeyDown(KeyCode.M))
				{
					Map.SetActive(true);
				}

				if(Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") <-0.5f || Input.GetAxis("Vertical") < -0.5f)
				{
					Map.SetActive(false);
				}
			}


		}

		public void GameOver()
		{
			GameFinished = true;
			UIManager.mInstance.Panels[UIManager.PanelElements.Winning].SetActive(true);
			enemyManager.gameObject.SetActive(false);
			GameManager.Instance.gameState = GameStates.Gameover;

		}


	}




}
