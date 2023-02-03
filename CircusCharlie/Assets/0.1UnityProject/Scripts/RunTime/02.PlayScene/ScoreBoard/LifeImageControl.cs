using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeImageControl : MonoBehaviour
{
    private GameObject life1 = default;
    private GameObject life2 = default;
    private GameObject life3 = default;
    // Start is called before the first frame update
    void Start()
    {
        life1 = gameObject.FindChildObj("Life_1");
        life2 = gameObject.FindChildObj("Life_2");
        life3 = gameObject.FindChildObj("Life_3");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
    }

    //플레이어 라이프 이미지 컨트롤 함수
    private void CheckLife()
    {
        if(GameManager.Instance.playerLife == 2)
        {
            life3.SetActive(false);
        }
        else if(GameManager.Instance.playerLife == 1)
        {
            life2.SetActive(false);
        }
        else if(GameManager.Instance.playerLife == 0)
        {
            life1.SetActive(false);
        }
    } //CheckLife
}
