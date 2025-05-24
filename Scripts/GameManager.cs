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
    public AudioSource audioSource;
    //�������
    public GameObject[] Players;
    //��ǰ���
    public int playerIndex = 0;
    //�Ƿ�ѡ��ؿ�ģʽ
    public int ChooseLevel = 0;
    public int LevelPass = 0;
    //��ҵ�ǰѪ��
    public float BloodNow = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //������ʼ��
        Init();
        //��ȡ��ʷ��߳ɼ�
        float score = PlayerPrefs.GetFloat("GameScore");
        //Debug.Log(score);

        //���ñ�����������
        audioSource.volume = 0.4f;
    }

    //���ʵ����
    private GameObject insPlayer;//ʵ������player
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
        Debug.Log("���뵽�³������³�������Ϊ��" + scene.name);
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
