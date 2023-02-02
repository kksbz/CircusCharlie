using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 10f;
    private float jumpForce = 8f;
    private bool isGround = false;
    private bool isRun = false;
    private bool isBackMove = false;
    private bool isClear = false;
    private bool lockTime = false;
    public GameObject tagetGoal = default;
    private Rigidbody2D playerRg2D = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRg2D = GetComponent<Rigidbody2D>();
        playerAni = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        lockTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    //플레이어 좌우이동 함수
    private void Move()
    {
        if (GameManager.Instance.playerDead == true)
        {
            return;
        }
        if (ButtonController.Instance.useRightBtn == true || Input.GetKey(KeyCode.D))
        {
            isRun = true;
            if (GameManager.Instance.playerMove == true)
            {
                gameObject.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            }
            playerAni.SetBool("Run", isRun);
        }
        else if (ButtonController.Instance.useLeftBtn == true || Input.GetKey(KeyCode.A))
        {
            isBackMove = true;
            if (GameManager.Instance.playerMove == true)
            {
                gameObject.transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            }
            playerAni.SetBool("BackMove", isBackMove);
        }
        else
        {
            isRun = false;
            isBackMove = false;
            playerAni.SetBool("Run", isRun);
            playerAni.SetBool("BackMove", isBackMove);
        }

        if (GameManager.Instance.playerMove == true)
        {
            tagetGoal.gameObject.SetActive(true);
        }
        else
        {
            tagetGoal.gameObject.SetActive(false);
        }

    } //Move

    //플레이어 점프 함수
    private void Jump()
    {
        if ((ButtonController.Instance.useJumpBtn == true || Input.GetKeyDown(KeyCode.Space)) && isGround == true)
        {
            isGround = false;
            playerRg2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        ButtonController.Instance.useJumpBtn = false;
        playerAni.SetBool("Ground", isGround);
    } //Jump

    //플레이어 죽음
    private void Die()
    {
        if(lockTime)
        {
            return;
        }
        lockTime = true;
        GameManager.Instance.playerDead = true;
        GameManager.Instance.playerLife -= 1;

        Debug.Log($"목숨:{GameManager.Instance.playerLife}");
        StartCoroutine(StageImageFalse());

        if (GameManager.Instance.playerLife == 0)
        {
            GFunc.LoadScene(GData.TITLE_SCENE_NAME);
            GameManager.Instance.InitGame();
        }
    }
    
    IEnumerator StageImageFalse()
    {
        playerAni.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        GameManager.Instance.ShowStageImage(true);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.ShowStageImage(false);
        GameManager.Instance.playerDead = false;
        playerAni.SetTrigger("Revival");
        lockTime = false;
    }

    private void Clear()
    {
        isClear = true;
        GameManager.Instance.ClearStage = true;
        playerAni.SetTrigger("ClearStage");
    }

    //트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DeadZone"))
        {
            Die();
        }

        if (collision.tag.Equals("Goal"))
        {
            Clear();
        }
        if (collision.tag.Equals("Ground"))
        {
            isGround = true;
            playerAni.SetBool("Ground", isGround);
        }

        if (collision.tag.Equals("Bonus") || collision.tag.Equals("BonusZone"))
        {
            if (collision.tag.Equals("Bonus"))
            {
                GameManager.Instance.score += 500;
            }
            else if (collision.tag.Equals("BonusZone"))
            {
                GameManager.Instance.score += 100;
                Debug.Log($"콜리젼네임 = {collision.name}");
            }
            Debug.Log($"점수: {GameManager.Instance.score}");
        }
    } //OnTriggerEnter2D

    //바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    } //OnCollisionEnter2D

    //바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떨어진 경우
        isGround = false;
    } //OnCollisionExit2D
}
