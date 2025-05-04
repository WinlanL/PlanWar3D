using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlanePanel : MonoBehaviour
{
    public Button StartGameBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Button backBtn;

    public GameObject[] players;
    private int showIndex = 0;
    void Start()
    {
        StartGameBtn.onClick.AddListener(StartGameBtnClick);
        leftBtn.onClick.AddListener(leftBtnClick);
        rightBtn.onClick.AddListener(rightBtnClick);
        backBtn.onClick.AddListener(backBtnClick);

    }

    
    void Update()
    {
        
    }
    public void StartGameBtnClick()
    {
        GameManager.Instance.LoadScene_04_Battle01();
    }
    public void leftBtnClick()
    {
        //Debug.Log("leftBtnClick");
        players[showIndex].SetActive(false);
        showIndex--;
        showIndex = showIndex < 0 ? players.Length - 1 : showIndex;
        players[showIndex].SetActive(true);
        //通知gamemanager当前选择的战机
        GameManager.Instance.playerIndex = showIndex;
    }
    public void rightBtnClick()
    {
        //Debug.Log("rightBtnClick");
        players[showIndex].SetActive(false);
        showIndex++;
        showIndex = showIndex % players.Length;
        players[showIndex].SetActive(true);
        //通知gamemanager当前选择的战机
        GameManager.Instance.playerIndex = showIndex;
    }
    public void backBtnClick()
    {
        GameManager.Instance.LoadScene_02_GameChoose();
    }
}
