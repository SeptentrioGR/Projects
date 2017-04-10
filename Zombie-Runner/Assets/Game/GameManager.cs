using UnityEngine;

public class GameManager
{
	private static GameManager instance = new GameManager();
	private TextUIInitialiser textUIInit;
	private float initialFixedDelta;

	public GameManager(){}

	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}


	public void Pause(bool isPaused)
	{
			
		if (isPaused)
		{
			initialFixedDelta = Time.fixedDeltaTime;
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		} else if (!isPaused)
		{
			Time.timeScale = 1;
			Time.fixedDeltaTime = initialFixedDelta;
		}

	}


	public void PauseGame()
	{
		
	}


	public void ResumeGame()
	{
		
	}




}
