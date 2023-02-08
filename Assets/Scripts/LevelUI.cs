using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelUI : MonoBehaviour
{
    bool isPaused = false;

    [SerializeField] GameObject pausePanel;

    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnlifeUpdate();
    public static OnlifeUpdate onlifeUpdate;
    // Start is called before the first frame update
    void Awake()
    {
        onScoreUpdate = ScoreSystem;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }



    public void PauseGame()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);

        Cursor.visible = isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            GameManager.Instance.gameState = GameManager.GameStates.Pause;
        }
        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameManager.Instance.gameState = GameManager.GameStates.Play;
        }
    }

    public void LifeSystemTracker()
    {

    }

     public void ScoreSystem()
        {

        }

    }
