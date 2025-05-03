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

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //通过SceneManager获取到当前激活的场景
        //Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        //Debug.Log(scene.buildIndex);

        //场景初始化
        Init();
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
    public void LoadScene_02_Main()
    {
        SceneManager.LoadScene("_02_Main");
    }
    public void LoadScene_03_Battle01()
    {
        SceneManager.LoadScene("_03_Battle01");
    }
    //当场景加载完成之后
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为：" + scene.name);
    }
    #endregion


}
