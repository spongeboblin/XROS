﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;


public class ButtonHandler : MonoBehaviour
{
    public void TakeAShot()
    {
        Core.Ins.ScreenshotManager.TakeAShot();
    }
}