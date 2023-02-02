using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public bool playerDead = default;
    public bool playerMove = default;
    public int playerMoveCount = default;
    public int score = 0;

    public static GameManager Instance
    {
        get
        {
            if(instance == null || instance == default)
            {
                return null;
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playerDead = false;
            playerMove = false;
            playerMoveCount = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    } //Awake
    

    public static void GetScore()
    {

    }

}
