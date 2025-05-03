using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TsetLoadScene : MonoBehaviour
{
    void Start()
    {
        //通过SceneManager获取到当前激活的场景
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

    //当场景加载完成之后
    private void sceneLoadedOk(Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("进入到新场景，新场景名称为："+scene.name);
    }
}
