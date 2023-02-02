using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFence : MonoBehaviour
{
    public GameObject objPrefab_1 = default;
    public GameObject objPrefab_2 = default;
    public GameObject objPrefab_3 = default;
    private GameObject fenceObj = default;
    private float spwanLate = 2f;
    private float spwanTime = default;
    private List<GameObject> fenceList = default;
    // Start is called before the first frame update
    void Start()
    {
        fenceList = new List<GameObject>();
        fenceList = SetupFenceList();
        fenceList = SetLocalScailObj(fenceList);
        spwanTime = 0f;
        // fenceList = SetFencePos(fenceList);
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

    private List<GameObject> SetFencePos(List<GameObject> fenceList_)
    {
        RectTransform parentObj = gameObject.transform.parent.GetComponent<RectTransform>();
        float widthSize = parentObj.sizeDelta.x * 0.5f;
        for (int i = 0; i < fenceList_.Count; i++)
        {
            if (fenceList_[i].name == "Fence1")
            {
                fenceList_[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + 100, 54f, 0f);
            }
            else if (fenceList_[i].name == "Fence2")
            {
                fenceList_[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + 100, 23f, 0f);
            }
            else if (fenceList_[i].name == "Fence3")
            {
                fenceList_[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + 100, -205f, 0f);
            }
        }
        return fenceList_;
    }

    //장애물 한개 가져오는 함수
    private GameObject GetFence(List<GameObject> fenceList_)
    {
        RectTransform parentObj = gameObject.transform.parent.GetComponent<RectTransform>();
        float widthSize = parentObj.sizeDelta.x * 0.5f;
        GameObject fence_ = default;
        int rN = Random.RandomRange(0, fenceList_.Count);
        float rNX = Random.RandomRange(100, 300);
        if (!fenceList_[rN].activeInHierarchy)
        {
            fence_ = fenceList_[rN];
            fence_.name = fenceList_[rN].name;

            if (fence_.name == "Fence1")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, 54f, 0f);
            }
            else if (fence_.name == "Fence2")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, 23f, 0f);
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
        GameObject fence_ = GetFence(fenceList_);
        if (spwanLate <= spwanTime)
        {
            spwanTime = 0f;
            if (fence_ == null || fence_ == default)
            {
                return null;
            }
            fence_.SetActive(true);
        }
        return fence_;
    }

    //여기서 코루틴 안먹힘 조건 Rect안들어감
    private void ObjSet(GameObject fence_)
    {
        if(fence_ == null || fence_ == default)
        {
            return;
        }

        if(fence_.GetComponent<RectTransform>().anchoredPosition.x <= 0)
        {
            StartCoroutine(SetActiveFalseObj(fence_));
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
        fenceObj = SpwanFence(fenceList);
        ObjSet(fenceObj);
    }
}
