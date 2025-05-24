using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public PlayerControl playerControl;
    public GameObject overPanel;
    public GameObject LevelOverPanel;
    public Text score_txt;
    public Text blood_txt;


    public Button returnBtn;
    public Button returnBtn2;

    void Start()
    {
        playerControl = GameManager.Instance.GetCurPlayer().GetComponent<PlayerControl>();
        returnBtn.onClick.AddListener(returnBtnClick);
        returnBtn2.onClick.AddListener(returnBtnClick);
        //gamepanel赋值
        GameManager.Instance.SetGamePanel(this);
    }

    public float blood = 0;
    void Update()
    {
        if (playerControl.hp <= 0 && GameManager.Instance.ChooseLevel == 1 && score < 100)
        {
            overPanel.SetActive(true);
        }
        if (playerControl.hp <= 0 && GameManager.Instance.ChooseLevel == 0)
        {
            overPanel.SetActive(true);
        }
        if (playerControl.hp <= 0 && GameManager.Instance.ChooseLevel == 1 && score >= 100)
        {
            LevelOverPanel.SetActive(true);
            GameManager.Instance.LevelPass = 1;
        }
        blood = GameManager.Instance.BloodNow;
        blood_txt.text = blood.ToString();
    }
    public void returnBtnClick()
    {
        GameManager.Instance.LoadScene_02_GameChoose();
        GameManager.Instance.ChooseLevel = 0;
    }

    public int score = 0;
    public void SetScore(int addscore)
    {
        //计算分数
        score += addscore;
        //显示分数
        score_txt.text = score.ToString();
        //设置以下分数
        PlayerPrefs.SetFloat("GameScore", score);
    }
}

