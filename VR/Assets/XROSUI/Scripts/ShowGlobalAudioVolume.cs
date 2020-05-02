using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowGlobalAudioVolume : ShowValue
{
    // Start is called before the first frame update
    void Start()
    {        
        Controller_Audio.EVENT_NewMasterVolume += HandleValueChange;
    }

    protected override string FormatValue(float f)
    {
        return "Volume: " + ((int)(f*100f)).ToString() + "%";// ((int)(Mathf.Pow(10f, value / 20f) * 100f)).ToString() + "%";
    }
}
