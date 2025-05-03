using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ȫ�ֹ�����
public class GameManager : MonoBehaviour
{
    #region ����ģʽ
    //Unityд������
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

        //ͨ��SceneManager��ȡ����ǰ����ĳ���
        //Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        //Debug.Log(scene.buildIndex);

        //������ʼ��
        Init();
    }

    void Update()
    {
        
    }


    //ϵͳ��ʼ��
    private void Init()
    {
        SceneManager.sceneLoaded += sceneLoadedOk;
    }

    public void SetGamePanel(GameOverPanel gamePanel)
    { 
        this.gamePanel = gamePanel;
    }

    //���÷���
    public void SetScore(int addscore)
    {
        this.gamePanel.SetScore(addscore);
    }

    #region ��������
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
    //�������������֮��
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("���뵽�³������³�������Ϊ��" + scene.name);
    }
    #endregion


}
