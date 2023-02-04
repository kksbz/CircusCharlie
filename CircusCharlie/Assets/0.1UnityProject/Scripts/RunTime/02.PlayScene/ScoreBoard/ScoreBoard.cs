using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private GameObject scoreObj = default;
    private GameObject stageObj = default;
    private GameObject bonusTimeObj = default;
    private float timeLate = 0.5f;
    private float timeCheck = default;
    // Start is called before the first frame update
    void Start()
    {
        scoreObj = gameObject.FindChildObj("Score");
        stageObj = gameObject.FindChildObj("StageNum");
        GFunc.SetTmpText(stageObj, GData.STAGE_1_NAME);
        bonusTimeObj = gameObject.FindChildObj("TimeText");
        timeCheck = 0f;
    } //Start

    // Update is called once per frame
    void Update()
    {
        BonusTimeCheck();
        GFunc.SetTmpText(scoreObj, $"{GameManager.Instance.score}");
        GFunc.SetTmpText(bonusTimeObj, $"- {GameManager.Instance.timeLimit}");
    } //Update

    private void BonusTimeCheck()
    {
        if(GameManager.Instance.playerDead == true || GameManager.Instance.ClearStage == true)
        {
            return;
        }
        timeCheck += Time.deltaTime;
        if(timeLate <= timeCheck)
        {
            timeCheck = 0f;
            GameManager.Instance.timeLimit -= 10;
        }
    } //BonusTimeCheck
}
