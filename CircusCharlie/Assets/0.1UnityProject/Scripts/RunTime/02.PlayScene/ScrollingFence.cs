using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingFence : MonoBehaviour
{
    private float objSpeed = 2f;
    private GameObject rootObj = default;
    private GameObject playerObj = default;
    private GameObject bgObj = default;
    private float tagetSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rootObj = GFunc.GetRootObj("GameObjs");
        playerObj = rootObj.FindChildObj("Player");
    }

    private void MoveFence()
    {
        if(gameObject.name != "Fence3")
        {
            transform.Translate(Vector2.left * objSpeed * Time.deltaTime);
        }

        if (GameManager.Instance.playerMoveCount == 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(Vector3.left * tagetSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(Vector3.right * tagetSpeed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveFence();
    }
}
