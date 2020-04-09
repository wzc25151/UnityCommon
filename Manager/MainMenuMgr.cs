using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuMgr : SingeBase<MainMenuMgr>
{

    public void OnClickNewPlay()
    {
        ConsoleMgr.Log("NewPlay");
        SceneManager.LoadSceneAsync("TestScene");
    }
    public void OnClickLoadGame()
    {
        ConsoleMgr.Log("LoadGame");
    }
    public void OnClickQuit()
    {
        ConsoleMgr.Log("Quit");
        Application.Quit();
    }
}
