using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeBase<T> where T : new()
{

    private static T instance;

    protected SingeBase()
    {
        Debug.Log(this.ToString() + "加载");
        init();
    }
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }

        return instance;
    }

    protected virtual void init()
    {

    }

}
