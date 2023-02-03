using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public void StartBtn()
    {
        StartCoroutine(StageImageActiveSetup());
    } //StartBtn

    IEnumerator StageImageActiveSetup()
    {
        GameManager.Instance.ShowStageImage(true);
        yield return new WaitForSeconds(2f);
        GFunc.LoadScene(GData.PLAY_SCENE_NAME);
    }
}
