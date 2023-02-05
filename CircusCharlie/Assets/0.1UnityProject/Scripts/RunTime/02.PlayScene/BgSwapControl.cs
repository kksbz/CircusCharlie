using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSwapControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && gameObject.tag.Equals("BgBack") && GameManager.Instance.playerMove == true && GameManager.Instance.playerMoveCount == 1)
        {
            // Debug.Log("왼쪽트리거 발동?");
            GameManager.Instance.playerMove = false;
            GameManager.Instance.playerMoveCount = 0;
        }
    }

}
