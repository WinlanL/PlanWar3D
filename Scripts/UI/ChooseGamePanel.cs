using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGamePanel : MonoBehaviour
{
    public Button Infinite_mode;
    public Button Level_mode;

    void Start()
    {
        Infinite_mode.onClick.AddListener(InfiniteGameBtnClick);
        Infinite_mode.onClick.AddListener(LevelGameBtnClick);
        //Infinite_mode.onClick.AddListener(InfiniteGameBtnClick);
        //Infinite_mode.onClick.AddListener(LevelGameBtnClick);
        //if (Infinite_mode.onClick)
        //{
        //    InfiniteGameBtnClick();
        //}
        //if (Level_mode.onClick != null)
        //{
        //    LevelGameBtnClick();
        //}
    }


    void Update()
    {
        
    }

    public void InfiniteGameBtnClick()
    {
        GameManager.Instance.LoadScene_03_ChoosePlane();
    }
    public void LevelGameBtnClick()
    {
        Debug.Log("level");
        GameManager.Instance.LoadScene_04_Battle01();
    }
}
