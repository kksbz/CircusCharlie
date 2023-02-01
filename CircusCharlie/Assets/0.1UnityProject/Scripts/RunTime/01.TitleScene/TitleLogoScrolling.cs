using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLogoScrolling : MonoBehaviour
{
    private Image logoImage = default;
    public Sprite titleLogoImage_1 = default;
    public Sprite titleLogoImage_2 = default;
    public Sprite titleLogoImage_3 = default;
    private float timeLate = default;
    private float timeCycle = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        logoImage = gameObject.GetComponent<Image>();
        timeLate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollingTitleLogo();
    }

    private void ScrollingTitleLogo()
    {
        timeLate += Time.deltaTime;
        if(timeLate <= timeCycle &&  timeLate <= 0.5f)
        {
            logoImage.sprite = titleLogoImage_3;
        }
        else if(timeLate <= timeCycle && 0.5f < timeLate && timeLate <= 1f)
        {
            logoImage.sprite = titleLogoImage_2;
        }
        else if(timeLate <= timeCycle && 1f < timeLate)
        {
            logoImage.sprite = titleLogoImage_1;
        }
        else
        {
            timeLate = 0f;
        }
    } //ScrollingTitleLogo
}
