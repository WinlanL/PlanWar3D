using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ȡ���µİ�ť�����ư�ť����¼�
//StartGamePanel����ʼ�������е�UI
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
