using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TsetLoadScene : MonoBehaviour
{
    void Start()
    {
        //ͨ��SceneManager��ȡ����ǰ����ĳ���
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.name);
        //Debug.Log(scene.buildIndex);
        SceneManager.sceneLoaded += sceneLoadedOk;
    }

    void Update()
    {
        //if(Input.GetButtonDown)
    }
    public void LoadScene_02_Main()
    {
        SceneManager.LoadScene("_02_Main");
    }

    //�������������֮��
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("���뵽�³������³�������Ϊ��"+scene.name);
    }
}
