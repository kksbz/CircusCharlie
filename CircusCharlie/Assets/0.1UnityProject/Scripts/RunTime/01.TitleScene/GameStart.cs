using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public void StartBtn()
    {
        GFunc.LoadScene(GData.PLAY_SCENE_NAME);
    } //StartBtn
}
