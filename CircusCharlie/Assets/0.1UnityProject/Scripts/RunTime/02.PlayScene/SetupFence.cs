using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFence : MonoBehaviour
{
    public GameObject objPrefab_1 = default;
    public GameObject objPrefab_2 = default;
    public GameObject objPrefab_3 = default;
    private GameObject fenceObj = default;
    private float spwanLate = 1f;
    private float spwanTime = default;
    private List<GameObject> fenceList = default;
    // Start is called before the first frame update
    void Start()
    {
        fenceList = new List<GameObject>();
        fenceList = SetupFenceList();
        fenceList = SetLocalScailObj(fenceList);
        spwanTime = 0f;
    }

    private List<GameObject> SetupFenceList()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject fence_ = default;
            GameObject fenceObj = default;
            if (i == 0)
            {
                fence_ = objPrefab_1;
            }
            else if (i == 1)
            {
                fence_ = objPrefab_2;
            }
            else if (i == 2)
            {
                fence_ = objPrefab_3;
            }

            fenceObj = Instantiate(fence_);
            fenceObj.SetActive(false);
            fenceList.Add(fenceObj);
            fenceObj.transform.parent = gameObject.transform;
        }
        return fenceList;
    } //SetupFence

    private List<GameObject> SetLocalScailObj(List<GameObject> fenceList_)
    {
        for (int i = 0; i < fenceList_.Count; i++)
        {
            fenceList_[i].name = $"Fence{i + 1}";
            fenceList_[i].transform.localScale = Vector3.one;
        }
        return fenceList_;
    } //SetLocalScailObj

    //장애물 한개 가져오는 함수
    private GameObject GetFence(List<GameObject> fenceList_)
    {
        RectTransform parentObj = gameObject.transform.parent.GetComponent<RectTransform>();
        float widthSize = parentObj.sizeDelta.x * 0.5f;
        GameObject fence_ = default;
        int rNBonus = Random.RandomRange(0, 10);
        int rN = Random.RandomRange(0, fenceList_.Count);
        float rNX = Random.RandomRange(100, 300);
        if (!fenceList_[rN].activeInHierarchy)
        {
            fence_ = fenceList_[rN];
            fence_.name = fenceList_[rN].name;

            if (fence_.name == "Fence1")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, 54f, 0f);
                if (rNBonus >= 8)
                {
                    fence_.FindChildObj("Bonus").gameObject.SetActive(true);
                }
            }
            else if (fence_.name == "Fence2")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, 23f, 0f);
                if (rNBonus <= 2)
                {
                    fence_.FindChildObj("Bonus").gameObject.SetActive(true);
                }
            }
            else if (fence_.name == "Fence3")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, -205f, 0f);
            }
        }
        return fence_;
    }

    private GameObject SpwanFence(List<GameObject> fenceList_)
    {
        spwanTime += Time.deltaTime;
        GameObject fence_ = default; 
        if (spwanLate <= spwanTime)
        {
            fence_ = GetFence(fenceList_);
            spwanTime = 0f;
            if (fence_ == null || fence_ == default)
            {
                return null;
            }
            fence_.SetActive(true);
        }
        return fence_;
    }

    private void ObjSet(GameObject fence_)
    {
        if (fence_ == null || fence_ == default)
        {
            return;
        }
    }
    IEnumerator SetActiveFalseObj(GameObject fence_)
    {
        yield return new WaitForSeconds(1f);
        fence_.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.playerMove == false)
        {
            fenceObj = SpwanFence(fenceList);
            ObjSet(fenceObj);
        }
    }
}
