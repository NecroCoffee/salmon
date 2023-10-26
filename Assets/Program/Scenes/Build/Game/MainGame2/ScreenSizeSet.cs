using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeSet : MonoBehaviour
{
    int screenWidth = 1024;
    int screenHeight = 576;

    private void Start()
    {
        Screen.SetResolution(screenWidth, screenHeight, false);
    }
}
