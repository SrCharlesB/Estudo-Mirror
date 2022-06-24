using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock 
{
    public static void Lock(bool lockstate)
    {
        switch(lockstate)
        {
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            break;
            case false:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            break;
        }
    }
}
