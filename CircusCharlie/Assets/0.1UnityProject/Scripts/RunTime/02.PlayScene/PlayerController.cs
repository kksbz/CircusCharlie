using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;
    private float playerSpeed = 0.005f;
    private float jumpForce = 8f;
    private bool isGround = false;
    private bool isRun = false;
    private bool isBackMove = false;
    private bool isDead = false;
    private Rigidbody2D playerRg2D = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRg2D = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move();
        }
        else
        {
            isRun = false;
            isBackMove = false;
            playerAni.SetBool("Run", isRun);
            playerAni.SetBool("BackMove", isBackMove);
        }
        Jump();
    }

    //플레이어 좌우이동 함수
    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isRun = true;
            // gameObject.transform.Translate(Vector3.right * playerSpeed);
            playerAni.SetBool("Run", isRun);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isBackMove = true;
            // gameObject.transform.Translate(Vector3.left * playerSpeed);
            playerAni.SetBool("BackMove", isBackMove);
        }
    } //Move

    //플레이어 점프 함수
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
            playerRg2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        playerAni.SetBool("Ground", isGround);
    } //Jump

    //플레이어 죽음
    private void Die()
    {
        isDead = true;
    }

    //트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Ground"))
        {
            isGround = true;
        }
        playerAni.SetBool("Ground", isGround);

    } //OnTriggerEnter2D

    //바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있을 때
        //if : 45도 보다 완만한 땅을 밟은 경우
        // if (collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_ANGLE_MIN)
        // {
        isGround = true;
        // }
    } //OnCollisionEnter2D

    //바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떨어진 경우
        isGround = false;
    } //OnCollisionExit2D
}
