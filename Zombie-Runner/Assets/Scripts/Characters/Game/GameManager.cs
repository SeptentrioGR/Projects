using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace ZombieRun
{
	public class GameManager : MonoBehaviour
	{

		public GameStates gameState;

		private static GameManager mInstance;
		private GameScreenManager GameScreenManager;	
		private InputManager input;
		private float initialFixedDelta;
		private float score;
		private bool isPaused;
		public bool TransitionEffect;
		private float targetAlpha = 255;
		public MouseLook mouseLook;
		public bool lockCursor = true;
		private bool m_cursorIsLocked = true;
		public bool loading = true;

		public void CheckIsLocked(bool value)
		{
			m_cursorIsLocked = value;
		}

		public static GameManager Instance
		{
			get
			{
				return mInstance;
			}

			set
			{
				mInstance = value;
			}
		}


		void Awake()
		{
			Debug.Log("Game Manager Awake");
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
			input = new InputManager();

			Initialise();

			DontDestroyOnLoad(gameObject);
		}

		void Initialise()
		{
			initialFixedDelta = Time.fixedDeltaTime;
		}

		void Update()
		{
			switch (gameState)
			{
				case GameStates.Menu:
					SetCursorLock(false);
					break;
				case GameStates.Game:
					GameLogic();
					break;
				case GameStates.Gameover:
					SetCursorLock(false);
					break;
			}
	
		}

		public void GameLogic()
		{

			if (input.PauseKeyIsPressed())
			{
				isPaused = !isPaused;
				Pause(isPaused);
				SetCursorLock(!isPaused);
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				//SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
			}


		}

		void FixedUpdate()
		{
			UpdateCursorLock();
		}

		public void UpdateCursorLock()
		{
			//if the user set "lockCursor" we check & properly lock the cursos
			if (lockCursor)
				InternalLockUpdate();
		}

		public void SetCursorLock(bool value)
		{
			lockCursor = value;
			if (!lockCursor)
			{//we force unlock the cursor if the user disable the cursor locking helper
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}

		private void InternalLockUpdate()
		{
			if (CheckIfPaused())
			{
				m_cursorIsLocked = false;
			}
			else if (!CheckIfPaused())
			{
				m_cursorIsLocked = true;
			}

			if (m_cursorIsLocked)
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			
			}
			else if (!m_cursorIsLocked)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

			}
		}



		public bool CheckIfPaused()
		{
			return isPaused;
		}

		public void Pause(bool isPaused)
		{
			if (isPaused)
			{

				Time.timeScale = 0;
				Time.fixedDeltaTime = 0;	
			}
			else if (!isPaused)
			{
				Time.timeScale = 1;
				Time.fixedDeltaTime = initialFixedDelta;
			}
		}


		public void ResetGame()
		{
			gameState = GameStates.Game;
			SetCursorLock(true);
			isPaused = false;
			Pause(false);
		}



	}
}
