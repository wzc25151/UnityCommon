using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LanguageMgr : SingeBase<LanguageMgr>
{
    // Start is called before the first frame update
    void Start()
    {
        SystemLanguage sl = Application.systemLanguage;
        string lang = "" + sl;
        if (lang.Contains("Chinese"))
        {
            // readLangFile();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static string Language = "Language";
    public static string Dialogue = "Dialogue";
    public static string fileName = "Main.zh-cn.txt";
    private void readLangFile()
    {
        // string fileName = "Main.en.txt";
        // string fileName = "Main.zh-cn.txt";
        // string exPath = "\\StreamingAssets\\Language\\Dialogue\\";
        string saPath = Application.streamingAssetsPath;
        string filePath = saPath + Path.DirectorySeparatorChar + Language + Path.DirectorySeparatorChar + Dialogue + Path.DirectorySeparatorChar + fileName;
        // string filePath = dataPath + exPath + fileName;
        Debug.Log("filePath = " + filePath);
        if (File.Exists(filePath))
        {
            string[] s = File.ReadAllLines(filePath);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string item in s)
            {
                string[] ss = item.Split('=');
                dic.Add(ss[0], ss[1]);
            }
            foreach (KeyValuePair<string, string> kv in dic)
            {
                Debug.Log("key = " + kv.Key + "\tvalue = " + kv.Value);
            }
        }

    }
}
