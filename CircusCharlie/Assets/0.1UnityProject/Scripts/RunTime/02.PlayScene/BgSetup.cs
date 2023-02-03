using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSetup : MonoBehaviour
{
    public GameObject bgPrefab = default;
    private float bgPrefabSize = default;
    private List<GameObject> bgList = default;
    private GameObject meterSign = default;
    // private int num = 4;
    // private int meter = 50;
    // Start is called before the first frame update
    void Start()
    {
        bgList = new List<GameObject>();
        bgList = SetupBgList();
        bgList = SetLocalScailBgObj(bgList);
        bgList = SetupBg(bgList);
        // bgPrefabSize = bgList[1].transform.localPosition.x * 0.5f;
    } //Start

    private List<GameObject> SetupBgList()
    {
        int meter_ = 90;
        for (int i = 0; i < 10; i++)
        {
            GameObject bg_ = Instantiate(bgPrefab);
            bg_.name = $"Bg{i + 1}";
            meterSign = bg_.FindChildObj("ShowMeter");
            // meterSign = bg_.FindChildObj("BgImage");
            // meterSign = meterSign.FindChildObj("ShowMeter");
            GFunc.SetTmpText(meterSign, $"{meter_}");
            if(bg_.name == "Bg10")
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

    /* private void RepositionFirstObj()
    {
        float lastScrObjCurrentXPos = bgList[bgList.Count - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos <= bgPrefabSize)
        {
            float lastScrObjInitXPos = (bgPrefabSize * 3) - 2;
            bgList[0].transform.localPosition = new Vector2(lastScrObjInitXPos, 0f);
            bgList[0].name = $"Bg{num + 1}";
            meterSign = bgList[0].FindChildObj("ShowMeter");
            GFunc.SetTmpText(meterSign, $"{meter}");
            bgList.Add(bgList[0]);
            bgList.RemoveAt(0);
        }
    } */
    // Update is called once per frame
    void Update()
    {
        //RepositionFirstObj();
    }
}
