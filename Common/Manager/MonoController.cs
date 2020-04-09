using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;
    private event UnityAction laterUpdateEvent;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateEvent != null)
        {
            updateEvent();

        }
    }

    void LateUpdate()
    {
        if (laterUpdateEvent != null)
        {
            laterUpdateEvent();
        }
    }

    public void AddUpdateListener(UnityAction fun)
    {
        updateEvent += fun;
    }
    public void RemoveUpdateListener(UnityAction fun)
    {
        updateEvent -= fun;
    }
    public void AddLaterUpdateListnener(UnityAction fun)
    {
        laterUpdateEvent += fun;
    }
    public void RemoveLaterUpdateListnener(UnityAction fun)
    {
        laterUpdateEvent -= fun;
    }
}
