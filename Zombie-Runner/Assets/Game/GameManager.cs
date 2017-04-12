using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	
	public GameStates gameState;

	private static GameManager mInstance;
	private GameScreenManager GameScreenManager;
	private EnemyManager enemyManager;
	private InputManager input;
	private GameObject Player;
	private float initialFixedDelta;

	private float score;
	private bool isPaused;
	public bool TransitionEffect;
	private float targetAlpha = 255;
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
		Instance = this;
		input = new InputManager();
		enemyManager = GameObject.FindObjectOfType<EnemyManager>();
		GameScreenManager = new GameScreenManager();
		GameScreenManager.Initialise();
		Player = GameObject.Find("Player");
	}

	void Update()
	{
		switch (gameState)
		{
			case GameStates.Menu:
				MainMenuLogic();
				break;
			case GameStates.Game:
				GameLogic();
				break;
		}
	}

	public void GameLogic()
	{
		GameScreenManager.SetGameScreenManager(Screens.Game);
		Player.GetComponent<PlayerScript>().getPlayerController().enabled = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		Player.SetActive(true);

		if (input.PauseKeyIsPressed())
		{
			isPaused = !isPaused;
			Pause(isPaused);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
		}

	}

	public void MainMenuLogic()
	{

		GameScreenManager.SetGameScreenManager(Screens.Menu);
		Player.GetComponent<PlayerScript>().getPlayerController().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		if (TransitionEffect)
		{
			Color c = UIManager.mInstance.Panels[UIManager.PanelElements.Fade].GetComponent<Image>().color;
			c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime);
			UIManager.mInstance.Panels[UIManager.PanelElements.Fade].GetComponent<Image>().color = c;
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
			initialFixedDelta = Time.fixedDeltaTime;
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
			UIManager.mInstance.Panels[UIManager.PanelElements.Pause].SetActive(true);
			
		} else if (!isPaused)
		{
			Time.timeScale = 1;
			Time.fixedDeltaTime = initialFixedDelta;
			UIManager.mInstance.Panels[UIManager.PanelElements.Pause].SetActive(false);
		}
	}

	public void PlayGame()
	{
		Debug.Log("Play Button");
		TransitionEffect = true;
		StartCoroutine("Fade");
	}


	public void PauseGame()
	{
		
	}


	public void ResumeGame()
	{
		
	}

	public void ResetGame()
	{

		UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled = false;
		UIManager.mInstance.Panels[UIManager.PanelElements.Fade].SetActive(false);
	}


	public void LoadGame()
	{

	}

	public void LoadMenu()
	{

	}

	IEnumerator Fade()
	{
		UIManager.mInstance.Panels[UIManager.PanelElements.Fade].SetActive(true);
		targetAlpha = 1;
		yield return new WaitForSeconds(5f);
		targetAlpha = 0;
		gameState = GameStates.Game;
		yield return new WaitForSeconds(5f);
	

	}

	public void ExitGame()
	{
		Application.Quit();
	}

}
