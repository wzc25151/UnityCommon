using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PanelBase : MonoBehaviour
{
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();


    void Awake()
    {

        FindChildControl<Button>();
        FindChildControl<Image>();
        FindChildControl<Text>();
        // FindChildControl<Slider>();
        // FindChildControl<Toggle>();
        // FindChildControl<ScrollRect>();
    }
    void Start()
    {

    }

    public virtual void Show()
    {

    }

    public virtual void Hide()
    {

    }

    protected T GetControl<T>(string controlName) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for (int i = 0; i < controlDic[controlName].Count; i++)
            {
                if (controlDic[controlName][i] is T)
                {
                    return controlDic[controlName][i] as T;
                }
            }
        }

        return null;
    }

    private void FindChildControl<T>() where T : UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        string objName;
        for (int i = 0; i < controls.Length; i++)
        {
            objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
            {
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] });
            }

        }
    }
}
