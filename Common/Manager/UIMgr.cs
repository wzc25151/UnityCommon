using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIMgr : SingeBase<UIMgr>
{
    public Dictionary<string, PanelBase> panelDic = new Dictionary<string, PanelBase>();
    public Transform canvas;
    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public enum UISort
    {
        BOT, MID, TOP, SYSTEM
    }

    public UIMgr()
    {
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("Prefabs/UI/Canvas");
        canvas = obj.transform;
        GameObject.DontDestroyOnLoad(obj);

        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        obj = ResMgr.GetInstance().Load<GameObject>("Prefabs/UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    public void ShowPanel<T>(string panelName, UISort sort = UISort.MID, UnityAction<T> callback = null) where T : PanelBase
    {
        if (panelDic.ContainsKey(panelName))
        {
            if (callback != null)
            {
                callback(panelDic[panelName] as T);
            }
            return;
        }

        ResMgr.GetInstance().LoadAsyn<GameObject>("Prefabs/UI/" + panelName, (obj) =>
        {
            Transform father = bot;
            switch (sort)
            {
                case UISort.MID:
                    father = mid;
                    break;
                case UISort.TOP:
                    father = top;
                    break;
                case UISort.SYSTEM:
                    father = system;
                    break;
            }
            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            T panel = obj.GetComponent<T>();
            panel.Show();
            if (callback != null)
            {
                callback(panel);
            }
            panelDic.Add(panelName, panel);
        });
    }
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].Hide();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }
}
