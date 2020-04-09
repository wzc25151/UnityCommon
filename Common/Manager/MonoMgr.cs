using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 让没有继承MonoBehaviour的类也可以执行Update帧更新方法
/// </summary>
public class MonoMgr : SingeBase<MonoMgr>
{
    public MonoController controller;
    public MonoMgr()
    {
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }
    public void AddUpdateListener(UnityAction fun)
    {
        controller.AddUpdateListener(fun);
    }
    public void RemoveUpdateListener(UnityAction fun)
    {
        controller.RemoveUpdateListener(fun);
    }

    public void AddLaterUpdateListener(UnityAction fun)
    {
        controller.AddLaterUpdateListnener(fun);
    }
    public void RemoveLaterUpdateListener(UnityAction fun)
    {
        controller.RemoveLaterUpdateListnener(fun);
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }


}
