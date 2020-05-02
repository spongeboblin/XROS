using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Visual : MonoBehaviour
{
    
    //Controller_Visual m_light;
    public float light_value = 0.0001f;
    // Start is called before the first frame update
    void Start()
    {
        //m_light = Core.Ins.VisualManager;
    }

    public void SetLight(float f)
    {
        //m_light.SetLight(f);
        Core.Ins.VisualManager.SetBrightness(f);
        light_value = f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
