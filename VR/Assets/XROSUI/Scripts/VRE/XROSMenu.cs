using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference
//https://en.wikibooks.org/wiki/C_Sharp_Programming/Delegates_and_Events

public delegate void XROSMenu_NewMenu(string menuName);
//public delegate void XROSInputHandler_NewRemoveInput();

public static class XROSMenu
{
    public static event XROSMenu_NewMenu EVENT_NewMenu;
    //public Controller_GameMenu 

    public static void AddMenu(XROSMenuTypes types)
    {
        AddMenu(types.ToString());
    }
    public static void AddMenu(string s)
    {
        if (EVENT_NewMenu != null)
        {
            EVENT_NewMenu(s);
            Debug.Log("Addmenu:"+ s);
        }
    }
}
