using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamePanel : MonoBehaviour
{
    public Button StartGameBtn;

    void Start()
    {
        StartGameBtn.onClick.AddListener(StartGameBtnClick);
    }


    void Update()
    {

    }

    public void StartGameBtnClick()
    {
        GameManager.Instance.LoadScene_03_Battle01();
    }
}
