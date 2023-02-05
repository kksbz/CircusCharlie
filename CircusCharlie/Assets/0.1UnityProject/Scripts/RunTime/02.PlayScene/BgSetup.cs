using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSetup : MonoBehaviour
{
    public GameObject bgPrefab = default;
    private float bgPrefabSize = default;
    private List<GameObject> bgList = default;
    private GameObject meterSign = default;
    private AudioSource bgAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        bgAudio = gameObject.GetComponent<AudioSource>();
        bgList = new List<GameObject>();
        bgList = SetupBgList();
        bgList = SetLocalScailBgObj(bgList);
        bgList = SetupBg(bgList);
        // bgPrefabSize = bgList[1].transform.localPosition.x * 0.5f;
    } //Start

    //BgList 미터표시,테그,오브젝트생성위치 세팅하는 함수
    private List<GameObject> SetupBgList()
    {
        int meter_ = 90;
        for (int i = 0; i < 10; i++)
        {
            GameObject bg_ = Instantiate(bgPrefab);
            bg_.name = $"Bg{i + 1}";
            meterSign = bg_.FindChildObj("ShowMeter");
            GFunc.SetTmpText(meterSign, $"{meter_}");
            if (bg_.name == "Bg10")
            {
                bg_.tag = "Bg";
            }
            bgList.Add(bg_);
            bg_.transform.parent = gameObject.transform;
            meter_ -= 10;
        }
        return bgList;
    } //SetupBg

    //로컬스케일 1,1,1로 초기화 72배로 생성되는 이슈있어서 강제로 설정함
    private List<GameObject> SetLocalScailBgObj(List<GameObject> bgList_)
    {
        for (int i = 0; i < bgList_.Count; i++)
        {
            bgList_[i].transform.localScale = Vector3.one;
        }
        return bgList_;
    } //SetLocalScailBgObj

    //우측으로 맵 나열하기
    private List<GameObject> SetupBg(List<GameObject> bgList_)
    {
        float xSize = bgList_[0].GetComponent<RectTransform>().sizeDelta.x;
        float xPos = 0f;
        for (int i = 0; i < bgList_.Count; i++)
        {
            bgList_[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, 0f);
            xPos += xSize;
        }
        return bgList_;
    } //SetupBg

    void Update()
    {
        //플레이어가 죽으면 배경음악 멈추고 아니면 시작
        if (GameManager.Instance.playerDead == true || GameManager.Instance.ClearStage)
        {
            bgAudio.Stop();
        }
        else
        {
            if (!bgAudio.isPlaying)
            {
                bgAudio.Play();
            }
        }
    }
}
