using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResMgr : SingeBase<ResMgr>
{
    /// <summary>
    /// 同步加载资源
    /// </summary>
    public T Load<T>(string name) where T : Object
    {

        T res = Resources.Load<T>(name);
        if (res is GameObject)
        {
            return GameObject.Instantiate(res);
        }
        else
        {
            return res;
        }
    }

    public void LoadAsyn<T>(string name, UnityAction<T> callback) where T : Object
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadAsyn<T>(name, callback));
    }

    private IEnumerator ReallyLoadAsyn<T>(string name, UnityAction<T> callback) where T : Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);

        yield return r;
        if (r.asset is GameObject)
        {
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            callback(r.asset as T);
        }
    }
}
