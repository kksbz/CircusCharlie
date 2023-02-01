using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    public RectTransform playerRectPos = default;
    private RectTransform bgRectPos =default;
    private float player_X = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRectPos = playerRectPos.GetComponent<RectTransform>();
        bgRectPos = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        player_X = PlayerXPos();
        ScrollingBgObj(player_X);
    }

    //플레이어 이동좌표 가져오는 함수
    private float PlayerXPos()
    {
        player_X = playerRectPos.anchoredPosition.x + 500f;
        // Debug.Log($"플레이어x좌표: {player_X}");
        return player_X;
    } //PlayerXPos

    //플레이어 이동거리만큼 배경이동
    private void ScrollingBgObj(float playerXPos_)
    {
        bgRectPos.anchoredPosition = new Vector2(-playerXPos_ * 3f, 0f);
    } //ScrollingBgObj
}
