using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : SingeBase<InputMgr>
{
    public InputMgr()
    {
        MonoMgr.GetInstance().AddLaterUpdateListener(InputUpdate);
    }


    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventMgr.GetInstance().EventTrigger<KeyCode>("某键按下", key);
        }
        if (Input.GetKeyUp(key))
        {
            EventMgr.GetInstance().EventTrigger<KeyCode>("某键抬起", key);

        }

    }

    private void InputUpdate()
    {
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
    }
}
