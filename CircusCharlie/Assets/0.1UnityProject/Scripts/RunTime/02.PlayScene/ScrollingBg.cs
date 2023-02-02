using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    private GameObject tagetObj = default;
    private GameObject mainTagetObj = default;
    private RectTransform playerRectPos = default;
    private RectTransform bgRectPos = default;
    private float player_X = default;
    private float bgSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        mainTagetObj = GFunc.GetRootObj("GameObjs");
        tagetObj = mainTagetObj.gameObject.FindChildObj("Player");
        playerRectPos = tagetObj.gameObject.GetComponent<RectTransform>();
        bgRectPos = gameObject.GetComponent<RectTransform>();
    }

    //플레이어 이동좌표 가져오는 함수
    private float PlayerXPos()
    {
        player_X = playerRectPos.anchoredPosition.x + 500f;
        return player_X;
    } //PlayerXPos

    private void MoveBg()
    {
        // Debug.Log($"무브bg에 들어온 체크 : {GameManager.Instance.playerMove}");
        if (GameManager.Instance.playerMove == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.left * bgSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.right * bgSpeed * Time.deltaTime);
            }
        }
    }
    //플레이어 이동거리만큼 배경이동
    private void ScrollingBgObj(float playerXPos_)
    {
        bgRectPos.anchoredPosition = new Vector2(-playerXPos_, 0f);
    } //ScrollingBgObj

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && gameObject.tag.Equals("Bg"))
        {
            GameManager.Instance.playerMove = true;
            if(GameManager.Instance.playerMoveCount >= 1)
            {
                GameManager.Instance.playerMove = false;
                GameManager.Instance.playerMoveCount = 0;
            }
            else
            {
                GameManager.Instance.playerMoveCount = 1;
            }
            Debug.Log($"체크 : {GameManager.Instance.playerMove}, {GameManager.Instance.playerMoveCount}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBg();
    }
}
