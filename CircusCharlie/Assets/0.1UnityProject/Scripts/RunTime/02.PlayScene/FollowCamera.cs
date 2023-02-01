using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public RectTransform playerPos = default;
    private RectTransform gameObj = default;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject playerObj = gameObject.FindChildObj("Player");
        // playerPos = playerObj.GetComponent<RectTransform>();
        gameObj = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObj.anchoredPosition = playerPos.anchoredPosition;
    }
}
