using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 objSize = default;
        BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        objSize.x = rectTransform.sizeDelta.x;
        objSize.y = rectTransform.sizeDelta.y;

        boxCollider2D.size = objSize;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
