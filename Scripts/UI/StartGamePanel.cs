using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//获取当下的按钮，控制按钮点击事件
//StartGamePanel管理开始界面所有的UI
public class StartGamePanel : MonoBehaviour
{
    public Button LoginBtn;
    
    void Start()
    {
        LoginBtn.onClick.AddListener(LoginBtnClick);
    }

    
    void Update()
    {
        
    }

    public void LoginBtnClick()
    {
        GameManager.Instance.LoadScene_02_Main();
    }
}
