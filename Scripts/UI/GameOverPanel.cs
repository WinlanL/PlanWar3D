using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public PlayerControl playerControl;
    public GameObject overPanel;
    public Text score_txt;


    public Button returnBtn;

    void Start()
    {
        overPanel.SetActive(false);
        returnBtn.onClick.AddListener(returnBtnClick);
        //gamepanel��ֵ
        GameManager.Instance.SetGamePanel(this);
    }
    void Update()
    {
        if (playerControl.hp <= 0)
        {
            overPanel.SetActive(true);
        }
    }
    public void returnBtnClick()
    {
        GameManager.Instance.LoadScene_03_ChoosePlane ();
    }

    public int score = 0;
    public void SetScore(int addscore)
    {
        //�������
        score += addscore;
        //��ʾ����
        score_txt.text = score.ToString();
    }
}

