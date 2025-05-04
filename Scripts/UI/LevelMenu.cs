using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button levelBtn1;
    public Button levelBtn2;
    public Button levelBtn3;
    public Button backBtn;
    
    void Start()
    {
        levelBtn1.onClick.AddListener(levelBtn1Click);
        levelBtn2.onClick.AddListener(levelBtn2Click);
        levelBtn3.onClick.AddListener(levelBtn3Click);
        backBtn.onClick.AddListener(backBtnClick);
    }

   
    void Update()
    {
        
    }
    public void levelBtn1Click()
    {
        GameManager.Instance.LoadScene_03_ChoosePlane();
    }
    public void levelBtn2Click()
    {
        GameManager.Instance.LoadScene_03_ChoosePlane();
    }
    public void levelBtn3Click()
    {
        GameManager.Instance.LoadScene_03_ChoosePlane();
    }
    public void backBtnClick()
    {
        GameManager.Instance.LoadScene_02_GameChoose();
    }
}
