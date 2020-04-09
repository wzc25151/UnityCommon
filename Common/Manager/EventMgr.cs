using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{

}
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> action;
    public EventInfo(UnityAction<T> action)
    {
        this.action += action;
    }
}
public class EventInfo : IEventInfo
{
    public UnityAction action;
    public EventInfo(UnityAction action)
    {
        this.action += action;
    }
}

public class EventMgr : SingeBase<EventMgr>
{
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    /// <summary>
    /// 向事件管理器注册要监听事件的name，触发时要执行的函数名action，一个name对应一种泛型T
    /// </summary>
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).action += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }
    public void AddEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).action += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }


    public void RemoveEventListen<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).action -= action;
        }
    }
    public void RemoveEventListen(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).action -= action;
        }
    }

    public void EventTrigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T>).action != null)
            {
                (eventDic[name] as EventInfo<T>).action.Invoke(info);
            }

        }
    }
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo).action != null)
            {
                (eventDic[name] as EventInfo).action.Invoke();
            }

        }
    }

    public void Clear()
    {
        eventDic.Clear();
    }
}
