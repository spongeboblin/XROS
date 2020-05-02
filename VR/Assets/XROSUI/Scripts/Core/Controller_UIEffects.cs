using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enum_XROSUI_Color
{
    OnGrab, OnHover, DefaultWhite
}

public class Controller_UIEffects : MonoBehaviour
{
    static Color Color_OnHover = new Color(0.929f, 0.094f, 0.278f);
    static Color Color_OnGrab = new Color(0.019f, 0.733f, 0.827f);

    public Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>();

    public Dictionary<Enum_XROSUI_Color, Color> colorDictionary2 = new Dictionary<Enum_XROSUI_Color, Color>();

    public Color[] ColorList;
    // Start is called before the first frame update
    void Start()
    {
        colorDictionary.Add(Enum_XROSUI_Color.OnHover.ToString(), Color_OnHover);
        colorDictionary.Add(Enum_XROSUI_Color.OnGrab.ToString(), Color_OnGrab);
        colorDictionary.Add(Enum_XROSUI_Color.DefaultWhite.ToString(), Color.white);

        colorDictionary2.Add(Enum_XROSUI_Color.OnHover, Color_OnHover);
        colorDictionary2.Add(Enum_XROSUI_Color.OnGrab, Color_OnGrab);
        colorDictionary2.Add(Enum_XROSUI_Color.DefaultWhite, Color.white);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color GetColor(Enum_XROSUI_Color colorName)
    {

        //Color c = colorDictionary[colorName.ToString()];
        Color c = colorDictionary2[colorName];
        return c;
        //return Color.white;
    }
}
