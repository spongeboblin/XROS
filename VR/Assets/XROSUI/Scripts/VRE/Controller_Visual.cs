using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Maintained by Powen & Sophie
//https://youtu.be/MDvPNNgIu7k

public delegate void EventHandler_NewBrightness(float newValue);

public class Controller_Visual : MonoBehaviour
{
    public static event EventHandler_NewBrightness EVENT_NewBrightness;

    float m_LightIntensity;

    float minValue = 0;
    float maxValue = 1;
    //public float lightIntensityAdjuster = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ////For Debugging
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            AdjustBrightness(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            AdjustBrightness(-0.1f);
        }
    }

    public void AdjustBrightness(float f)
    {
        m_LightIntensity += f;
        //Dev.Log("New Light: " + f);
        SetBrightness(m_LightIntensity);
    }

    public float GetBrightness()
    {
        return m_LightIntensity;
    }

    public void SetBrightness(float f)
    {

        if (f > maxValue)
        {
            f = maxValue;
        }
        else if (f < minValue)
        {
            f = minValue;
        }

        if (EVENT_NewBrightness != null)
        {
            EVENT_NewBrightness(f);
        }

        m_LightIntensity = f;
        RenderSettings.ambientLight = new Color(f, f, f, 1);
//        Debug.Log("Current brightness " + f);
    }
}