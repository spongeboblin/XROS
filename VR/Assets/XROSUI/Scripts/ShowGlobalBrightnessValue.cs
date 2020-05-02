using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGlobalBrightnessValue : ShowValue
{
    // Start is called before the first frame update
    void Start()
    {
        Controller_Visual.EVENT_NewBrightness += HandleValueChange;
    }

    protected override string FormatValue(float f)
    {
        return "Brightness: " + ((int)(f * 100f)).ToString() + "%";
    }
}
