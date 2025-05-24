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
        Level_mode.onClick.AddListener(LevelGameBtnClick);
    }


    void Update()
    {
        
    }

    public void InfiniteGameBtnClick()
    {
        GameManager.Instance.ChooseLevel = 0;
        GameManager.Instance.LoadScene_03_ChoosePlane();
    }
    public void LevelGameBtnClick()
    {
        GameManager.Instance.ChooseLevel = 1;
        GameManager.Instance.LoadScene_0203_LevelMenu();
    }
}
