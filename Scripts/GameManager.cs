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
    //玩家数组
    public GameObject[] Players;
    //当前玩家
    public int playerIndex = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //场景初始化
        Init();
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
    public void LoadScene_03_ChoosePlane()
    {
        SceneManager.LoadScene("_03_ChoosePlane");
    }
    public void LoadScene_04_Battle01()
    {
        SceneManager.LoadScene("_04_Battle01");
    }
    //public void LoadScene_01_02_ChooseMenu()
    //{
    //    SceneManager.LoadScene("_01_02_ChooseMenu");
    //}
    //当场景加载完成之后
    //private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    //{
    //    Debug.Log("进入到新场景，新场景名称为：" + scene.name);
    //    if (scene.name == "_04_Battle01")
    //    {
    //        InstantiatePlayer();
    //    }
    //}
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为：" + scene.name);
        if (scene.name == "_04_Battle01")
        {
            InstantiatePlayer();
        }
    }
    #endregion


}
