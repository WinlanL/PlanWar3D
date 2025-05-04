using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlanePanel : MonoBehaviour
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
        GameManager.Instance.LoadScene_04_Battle01();
    }
}
