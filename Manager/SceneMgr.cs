using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : SingeBase<SceneManager>
{

    public void LoadScene(string name, UnityAction fun)
    {
        SceneManager.LoadScene(name);
        fun();
    }

    public void LoadSceneAsyn(string name, UnityAction fun)
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsyn(name, fun));
    }

    private IEnumerator ReallyLoadSceneAsyn(string name, UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            EventMgr.GetInstance().EventTrigger("进度条更新",ao.progress);
            yield return ao.progress;
        }
        fun();
    }

}
