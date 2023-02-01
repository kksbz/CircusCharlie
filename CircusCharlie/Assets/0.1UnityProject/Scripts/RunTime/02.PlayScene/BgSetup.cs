using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSetup : MonoBehaviour
{
    public GameObject bgPrefab = default;
    private List<GameObject> bgList = default;
    // Start is called before the first frame update
    void Start()
    {
        bgList = new List<GameObject>();
        bgList = SetupBgList();
        bgList = SetLocalScailBgObj(bgList);
        bgList = SetupBg(bgList);
        // for (int i = 0; i < bgList.Count; i++)
        // {
        //     float a=  bgList[i].GetComponent<RectTransform>().anchoredPosition.x;
        //     Debug.Log($"길이: {a}");
        // }
    } //Start


    private List<GameObject> SetupBgList()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject bg_ = Instantiate(bgPrefab);
            bgList.Add(bg_);
            bg_.transform.parent = gameObject.transform;
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

    // Update is called once per frame
    void Update()
    {

    }
}
