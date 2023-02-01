using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    private GameObject tagetObj = default;
    private RectTransform playerRectPos = default;
    private RectTransform bgRectPos =default;
    private float player_X = default;
    private float bgSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        tagetObj = GFunc.GetRootObj("GameObjs");
        tagetObj = tagetObj.gameObject.FindChildObj("Player");
        playerRectPos = tagetObj.gameObject.GetComponent<RectTransform>();
        bgRectPos = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        player_X = PlayerXPos();
        MoveBg();
        //ScrollingBgObj(player_X);
    }

    //플레이어 이동좌표 가져오는 함수
    private float PlayerXPos()
    {
        player_X = playerRectPos.anchoredPosition.x + 500f;
        return player_X;
    } //PlayerXPos

    private void MoveBg()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.left * bgSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.right * bgSpeed);
        }
    }
    //플레이어 이동거리만큼 배경이동
    private void ScrollingBgObj(float playerXPos_)
    {
        bgRectPos.anchoredPosition = new Vector2(-playerXPos_ * 3f, 0f);
    } //ScrollingBgObj
}
