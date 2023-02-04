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
    public int timeLimit = default;
    public int score = 0;
    public bool isGameOver = false;

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
        playerLife = 0;
        playerDead = false;
        playerMove = false;
        ClearStage = false;
        isGameOver = false;
        timeLimit = 5000;
        score = 0;
        playerMoveCount = 0;
    }

    //게임오버시 키입력 처리함수
    public void InputAny()
    {
        if(isGameOver == true)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                GameManager.instance.InitGame();
                GFunc.LoadScene(GData.TITLE_SCENE_NAME);
            }
        }
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

    private void Update()
    {
        InputAny();
    }
}
