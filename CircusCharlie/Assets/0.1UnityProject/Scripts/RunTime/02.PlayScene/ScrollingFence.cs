using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFence : MonoBehaviour
{
    private float objSpeed = 2f;
    private GameObject rootObj = default;
    private GameObject playerObj = default;
    private GameObject bgObj = default;
    private RectTransform objAPosX = default;
    private float tagetSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        objAPosX = gameObject.GetComponent<RectTransform>();
        rootObj = GFunc.GetRootObj("GameObjs");
        playerObj = rootObj.FindChildObj("Player");
    }

    private void MoveFence()
    {
        if(GameManager.Instance.playerDead == true)
        {
            return;
        }
        
        if (gameObject.name != "Fence3")
        {
            transform.Translate(Vector2.left * objSpeed * Time.deltaTime);
        }

        if (GameManager.Instance.playerMoveCount == 0)
        {
            if (ButtonController.Instance.useRightBtn == true || Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.left * tagetSpeed * Time.deltaTime);
            }
            else if (ButtonController.Instance.useLeftBtn == true || Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.right * tagetSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(1f);
        if (gameObject.name != "Fence3")
        {
            if (gameObject.FindChildObj("Bonus").gameObject.activeInHierarchy)
            {
                gameObject.FindChildObj("Bonus").gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MoveFence();
        if (objAPosX.anchoredPosition.x <= -640f)
        {
            StartCoroutine(SetActiveFalse());
        }
    }
}
