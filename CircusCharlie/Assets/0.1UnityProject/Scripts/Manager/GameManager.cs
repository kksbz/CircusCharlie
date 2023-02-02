using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public bool playerDead = default;
    public bool playerMove = default;
    public bool ClearStage = default;
    public int playerMoveCount = default;
    public int playerLife = default;
    public int score = 0;

    public static GameManager Instance
    {
        get
        {
            if (instance == null || instance == default)
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
            InitGame();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    } //Awake

    public void InitGame()
    {
        playerLife = 3;
        playerDead = false;
        playerMove = false;
        ClearStage = false;
        score = 0;
        playerMoveCount = 0;
    }
    public void GetScore()
    {

    }

    public void ShowStageImage(bool die)
    {
        GameObject rootObj = GFunc.GetRootObj("UiObjs");
        GameObject stageObj = rootObj.FindChildObj("StageImage");
        stageObj.SetActive(die);
    }
}
