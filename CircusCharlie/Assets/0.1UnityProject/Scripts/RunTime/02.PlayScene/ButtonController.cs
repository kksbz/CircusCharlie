using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private static ButtonController instance = null;
    public static ButtonController Instance
    {
        get
        {
            if(instance == null && instance == default)
            {
                instance = null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public Button rightBtn = default;
    public Button leftBtn = default;
    public Button jumpBtn = default;
    public bool useRightBtn = false;
    public bool useLeftBtn = false;
    public bool useJumpBtn = false;
    // Start is called before the first frame update
    void Start()
    {
        //점프버튼은 드래그할필요없어서 온클릭사용함
        jumpBtn.onClick.AddListener(() => 
        {
            useJumpBtn = true;
        });
    }
}

