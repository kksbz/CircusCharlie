using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //버튼눌렀을때 어느버튼 눌렀는지 체크하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.gameObject.name == "RightBtn")
        {
            ButtonController.Instance.useRightBtn = true;
        }
        else if(this.gameObject.name == "LeftBtn")
        {
            ButtonController.Instance.useLeftBtn = true;
        }
    } //OnPointerDown

    //버튼땠을때 어느버튼 땠는지 체크하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        if(this.gameObject.name == "RightBtn")
        {
            ButtonController.Instance.useRightBtn = false;
        }
        else if(this.gameObject.name == "LeftBtn")
        {
            ButtonController.Instance.useLeftBtn = false;
        }
    } //OnPointerUp
}
