using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    } //Start

    //플레이어 이동거리만큼 장애물도 이동하는 함수
    private void MoveBg()
    {
        //if : 플레이어가 마지막맵에 진입하기전에는 배경이 움직이고 
        //진입후에는 배경은멈추고 플레이어가 움직이기 때문에 bool체크값 줌
        if(GameManager.Instance.playerDead == true || GameManager.Instance.ClearStage == true)
        {
            return;
        }

        if (GameManager.Instance.playerMove == false)
        {
            if (ButtonController.Instance.useRightBtn == true || Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.left * GData.MOVE_SPEED * Time.deltaTime);
            }
            else if (ButtonController.Instance.useLeftBtn == true || Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.right * GData.MOVE_SPEED * Time.deltaTime);
            }
        }
    } //MoveBg

    private void EndMapMoveBreak()
    {
        //문제찾음 마지막맵의 앵커포지션x값이 0이하로 안떨어지게 만들면됨
    }

    //플레이어위치에 따라 무빙대상이 달라지게 체크하는 트리거 (마지막맵말곤 배경만 움직이게 해놔서 예외처리한거임)
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
            // Debug.Log($"체크 : {GameManager.Instance.playerMove}, {GameManager.Instance.playerMoveCount}");
        }
    } //OnTriggerEnter2D

    // Update is called once per frame
    void Update()
    {
        MoveBg();
    }
}
