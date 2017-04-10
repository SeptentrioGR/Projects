using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	public static Game instance;
	public GameStates gameState;
	private GameManager GManager;
	private InputManager input;
	private EnemyManager enemyManager;
	private float score;
	private bool isPaused;

	void Awake()
	{
		instance = this;
	}

	void Start () {
		input = new InputManager();
		GManager = new GameManager();
		UIManager.Instance.Initialize();
	}
	

	void Update () {
		switch (gameState)
		{
			case GameStates.Loading:
				break;
			case GameStates.Menu:
				break;
			case GameStates.Game:
				break;
			case GameStates.Gamover:
				break;
			case GameStates.Paused:
				break;
		}

		if (input.PauseKeyIsPressed())
		{
			isPaused = !isPaused;
			GManager.Pause(isPaused);
		} 


	}




}
