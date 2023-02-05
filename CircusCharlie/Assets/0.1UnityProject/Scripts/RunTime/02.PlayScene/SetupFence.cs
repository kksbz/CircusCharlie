using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupFence : MonoBehaviour
{
    public GameObject objPrefab_1 = default;
    public GameObject objPrefab_2 = default;
    public GameObject objPrefab_3 = default;
    public GameObject objPrefab_4 = default;
    public GameObject objPrefab_5 = default;
    public GameObject tagetGoal = default;
    private GameObject fenceObj = default;
    private float spwanLate = 1.5f;
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

    //팬스리스트 셋업하는 함수
    private List<GameObject> SetupFenceList()
    {
        for (int i = 0; i < 5; i++)
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
            else if (i == 3)
            {
                fence_ = objPrefab_4;
            }
            else if (i == 4)
            {
                fence_ = objPrefab_5;
            }

            fenceObj = Instantiate(fence_);
            fenceObj.SetActive(false);
            fenceList.Add(fenceObj);
            fenceObj.transform.parent = gameObject.transform;
        }
        return fenceList;
    } //SetupFence

    //팬스리스트 스케일값 1,1,1로 설정하는 함수
    private List<GameObject> SetLocalScailObj(List<GameObject> fenceList_)
    {
        //리스트에 넣기전에 설정하면 설정값이 제대로들어가는데 꺼낼때 설정값이 바뀜
        //켄버스안의 부모오브젝트의 스케일의 영향을 받는게 문제인게 확인됨
        //부모 연결을 끊고 스케일 재설정후 부모연결을 하는 방법시도 =>안먹힘
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

        //장애물 가져올 때 장애물의 위치값 설정
        if (!fenceList_[rN].activeInHierarchy)
        {
            fence_ = fenceList_[rN];
            fence_.name = fenceList_[rN].name;

            if (fence_.name == "Fence1" || fence_.name == "Fence3")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, -33f, 0f);
                if (rNBonus >= 8)
                {
                    fence_.FindChildObj("Bonus").gameObject.SetActive(true);
                }
            }
            else if (fence_.name == "Fence2" || fence_.name == "Fence4")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX + 100, -57f, 0f);
                if (rNBonus <= 2)
                {
                    fence_.FindChildObj("Bonus").gameObject.SetActive(true);
                }
            }
            else if (fence_.name == "Fence5")
            {
                fence_.GetComponent<RectTransform>().anchoredPosition = new Vector3(widthSize + rNX, -238f, 0f);
            }
        }
        return fence_;
    } //GetFence

    //장애물 스폰하는 함수
    private GameObject SpwanFence(List<GameObject> fenceList_)
    {
        spwanTime += Time.deltaTime;
        GameObject fence_ = default;
        if (GameManager.Instance.playerMove == false && GameManager.Instance.playerDead == false)
        {
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
        }
        return fence_;
    } //SpwanFence

    //스폰되는 장애물 값 예외처리 함수
    private void ObjSet(GameObject fence_)
    {
        if (fence_ == null || fence_ == default)
        {
            return;
        }
    } //ObjSet

    //플레이어가 마지막맵에 도착했을때 골대 셋업하는 함수
    private void ShowGoalObj()
    {
        if (GameManager.Instance.playerMove == true)
        {
            tagetGoal.gameObject.SetActive(true);
        }
        else
        {
            tagetGoal.gameObject.SetActive(false);
        }
    } //ShowGoalObj

    //플레이어가 죽었을 때 모든장애물 리셋하는 함수
    private void AllFenceActiveFalse(List<GameObject> fenceList_)
    {
        if (GameManager.Instance.playerDead == true)
        {
            foreach (GameObject fence_ in fenceList_)
            {
                fence_.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AllFenceActiveFalse(fenceList);
        fenceObj = SpwanFence(fenceList);
        ObjSet(fenceObj);
        ShowGoalObj();
    }
}
