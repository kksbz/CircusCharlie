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
        timeLimit = 5000;
        score = 0;
        playerMoveCount = 0;
    }

    public void ReStartGame()
    {

        GameObject rootObj = GFunc.GetRootObj("UiObjs");
        GameObject endObj = rootObj.FindChildObj("EndImage");
        GameObject goTitleObj = endObj.FindChildObj("GoToTitle");

        endObj.SetActive(true);
        StartCoroutine(SetActiveObj(goTitleObj));
        
            
        
    }

    IEnumerator SetActiveObj(GameObject goTitleObj_)
    {
        //여기부분 버튼누르는거 해결해야됨
        while (true)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                GameManager.instance.InitGame();
                GFunc.LoadScene(GData.TITLE_SCENE_NAME);
            }
            goTitleObj_.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            goTitleObj_.SetActive(false);
            yield return new WaitForSeconds(0.5f);
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
}
