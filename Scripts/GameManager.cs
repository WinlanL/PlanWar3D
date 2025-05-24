using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//全局管理者
public class GameManager : MonoBehaviour
{
    #region 单例模式
    //Unity写法单例
    public static GameManager Instance;
    public void Awake()
    {
        Instance = this;
    }
    #endregion

    private GameOverPanel gamePanel;
    public AudioSource audioSource;
    //玩家数组
    public GameObject[] Players;
    //当前玩家
    public int playerIndex = 0;
    //是否选择关卡模式
    public int ChooseLevel = 0;
    public int LevelPass = 0;
    //玩家当前血量
    public float BloodNow = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //场景初始化
        Init();
        //获取历史最高成绩
        float score = PlayerPrefs.GetFloat("GameScore");
        //Debug.Log(score);

        //设置背景音乐音量
        audioSource.volume = 0.4f;
    }

    //玩家实例化
    private GameObject insPlayer;//实例化的player
    public void InstantiatePlayer()
    {
        insPlayer = Instantiate(Players[playerIndex], new Vector3(0, 0, 0), Quaternion.identity);
    }

    public GameObject GetCurPlayer()
    { 
        return insPlayer;
    }

    void Update()
    {
        
    }


    //系统初始化
    private void Init()
    {
        SceneManager.sceneLoaded += sceneLoadedOk;
    }

    public void SetGamePanel(GameOverPanel gamePanel)
    { 
        this.gamePanel = gamePanel;
    }

    //设置分数
    public void SetScore(int addscore)
    {
        this.gamePanel.SetScore(addscore);
    }

    #region 场景加载
    public void LoadScene_01_StartMenu1()
    {
        SceneManager.LoadScene("_01_StartMenu1");
    }
    public void LoadScene_02_GameChoose()
    {
        SceneManager.LoadScene("_02_GameChoose");
    }
    public void LoadScene_03_ChoosePlane()
    {
        SceneManager.LoadScene("_03_ChoosePlane");
    }
    public void LoadScene_04_Battle01()
    {
        SceneManager.LoadScene("_04_Battle01");
    }
    public void LoadScene_0203_LevelMenu()
    {
        SceneManager.LoadScene("_0203_LevelMenu");
    }


    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为：" + scene.name);
        if (scene.name == "_04_Battle01")
        {
            InstantiatePlayer();
            playerIndex = 0;
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = 0.4f;
        }
    }
    #endregion


}
