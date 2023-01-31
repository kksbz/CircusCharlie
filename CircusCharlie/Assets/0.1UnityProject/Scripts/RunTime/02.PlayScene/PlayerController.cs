using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;
    public float PlayerSpeed = 5f;
    public float jumpForce = 100f;
    private bool isGround = false;
    private bool isRun = false;
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
        Move();
        Jump();
        
    }
    private void Move()
    {
        isRun = true;
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * PlayerSpeed;
        Vector2 newVelocity = new Vector2(xSpeed, 0f);
        playerRg2D.velocity = newVelocity;
        isRun = false;
        playerAni.SetBool("Run", isRun);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
            playerRg2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        playerAni.SetBool("Ground", isGround);
    }

    //트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Ground"))
        {
            isGround = true;
        }

    } //OnTriggerEnter2D

    //바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있을 때
        //if : 45도 보다 완만한 땅을 밟은 경우
        if (collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_ANGLE_MIN)
        {
            isGround = true;
        }
    } //OnCollisionEnter2D

    //바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떨어진 경우
        isGround = false;
    } //OnCollisionExit2D
}
