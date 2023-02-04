using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;


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
       
    {
      
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

    

}
