using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    bool isPaused= false;

   [SerializeField] GameObject pausePanel;

    public enum GameStates
    {
        None,
        Play,
        Pause,

    }
    public GameStates gameState = GameStates.Play; 


    public static GameManager Instance
    {
        get { return instance; }
        set { instance = value; }

    }
    private void Start()
    {
        CheckGameManager();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void CheckGameManager()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PauseGame()
    {
        isPaused =!isPaused;
        pausePanel.SetActive(isPaused);

        Cursor.visible = isPaused;

        if(isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            gameState = GameStates.Pause;
        }
        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            gameState = GameStates.Play;
        }
    }

}
