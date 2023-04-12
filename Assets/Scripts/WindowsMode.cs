using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsMode : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Screen.fullScreen)
            {
                Screen.fullScreen = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Screen.fullScreen = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }
}
