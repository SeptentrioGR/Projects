using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameStates
    {
        Loading, Menu, Game, Paused, GAMEOVER
    }
    public GameStates gameState;
    public float score { get; set; }
    public bool isPaused { get; set; }

    private float initialFixedDelta;
    private EnemyManager enemyManager;

    public Locale mLocale;
    TextUIInitialiser textUIInit;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        initialFixedDelta = Time.fixedDeltaTime;
        mLocale = new Locale();
        mLocale.LoadTextAssets();
        mLocale.PrintAllAssets();
        mLocale.LoadResource("en");
    }


    void Update()
    {
        switch (gameState)
        {
            case GameStates.Loading:
                break;
            case GameStates.Menu:
                break;
            case GameStates.Paused:
                break;
            case GameStates.Game:
                GameLogic();
                break;
            case GameStates.GAMEOVER:
                break;
        }
    }

    public void GameLogic()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }




    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = initialFixedDelta;
    }




}
