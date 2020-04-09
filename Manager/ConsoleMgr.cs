using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
 *自定义的控制台显示，需要作弊的时候可以在这里输入代码
 *显示界面已经完成，还没有制作作弊码列表
*/
public class ConsoleMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public static ConsoleMgr instance;
    private static GameObject consoleView;
    private static Text textView;
    private static InputField inputField;
    private static ScrollRect contPanel;

    private static bool isShowLog = true;
    public GameObject prefabConsoleView;
    void Start()
    {



        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        if (consoleView == null)
        {

            consoleView = GameObject.Instantiate(prefabConsoleView);
            textView = consoleView.GetComponentInChildren<Text>();
            inputField = consoleView.GetComponentInChildren<InputField>();
            contPanel = consoleView.GetComponentInChildren<ScrollRect>();

            consoleView.transform.SetParent(GameObject.Find("Canvas").transform);
            RectTransform consoleViewRect = consoleView.GetComponent<RectTransform>();
            // consoleViewRect.sizeDelta = Vector3.zero;
            UIUtil.instance.SetAnchor(consoleViewRect, UIUtil.AnchorPresets.TopRight);
            UIUtil.instance.SetPivot(consoleViewRect, UIUtil.PivotPresets.TopRight);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(consoleView);
        }

        // Transform consoleTransform = GameObject.Find("Canvas").transform.Find("ConsoleView");
        // if (consoleTransform != null)
        // {
        //     consoleView = consoleTransform.gameObject;
        //     textView = consoleView.GetComponentInChildren<Text>();
        //     inputField = consoleView.GetComponentInChildren<InputField>();
        //     contPanel = consoleView.GetComponentInChildren<ScrollRect>();
        //     DontDestroyOnLoad(gameObject);
        //     DontDestroyOnLoad(consoleView);

        // }

        // foreach (GameObject item in GameObject.FindGameObjectsWithTag("UI"))
        // {
        //     if (item.name == "ConsoleView")
        //     {
        //         consoleView = item;
        //     }
        // }

    }

    public static void AddText(string str)
    {
        if (textView == null)
        {
            return;
        }
        if (string.IsNullOrEmpty(str))
        {
            return;
        }
        textView.text += str + "\n";
        //检测是否输入指令
        VerifyCode(str);
        contPanel.verticalNormalizedPosition = 0f;
    }

    private static void ClearText()
    {
        textView.text = "控制台：\n";
        contPanel.verticalNormalizedPosition = 0f;
    }

    void Update()
    {
        SwitchDisplay();
        InputSubmit();
    }
    private static void SwitchDisplay()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            consoleView.gameObject.SetActive(!consoleView.gameObject.activeInHierarchy);

            // plane.enabled = !plane.enabled;

        }

    }

    private static void InputSubmit()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddText(inputField.text);
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }

    private static void VerifyCode(string str)
    {
        if (str.ToUpper().Equals("CLS"))
        {
            ClearText();
        }
    }

    public static void Log(string log)
    {
        if (isShowLog)
        {
            Debug.Log(log);
            AddText(log);
        }
    }
}
