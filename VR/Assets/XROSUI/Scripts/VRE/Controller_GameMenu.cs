using System;
using System.Collections.Generic;
using UnityEngine;
public enum XROSMenuTypes { Menu_None, Menu_General, Menu_Screenshot, Menu_Setting, Menu_Audio, Menu_Visual, Menu_User, Menu_Credit }

public class Controller_GameMenu : MonoBehaviour
{
    //public GameObject UICanvas;
    public GameObject Menu_None;
    public GameObject Menu_General;
    public GameObject Menu_Screenshot;
    public GameObject Menu_Setting;
    public GameObject Menu_Audio;
    public GameObject Menu_Visual;
    public GameObject Menu_User;
    public GameObject Menu_Credit;

    public IDictionary<XROSMenuTypes, GameObject> menus = new Dictionary<XROSMenuTypes, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        XROSMenu.EVENT_NewMenu += OpenMenu;
        //print(menuTypes.Menu_General.ToString());
        menus.Add(XROSMenuTypes.Menu_None, Menu_None);
        menus.Add(XROSMenuTypes.Menu_General, Menu_General);
        menus.Add(XROSMenuTypes.Menu_Screenshot, Menu_Screenshot);
        menus.Add(XROSMenuTypes.Menu_Setting, Menu_Setting);
        menus.Add(XROSMenuTypes.Menu_Audio, Menu_Audio);
        menus.Add(XROSMenuTypes.Menu_Visual, Menu_Visual);
        menus.Add(XROSMenuTypes.Menu_User, Menu_User);
        menus.Add(XROSMenuTypes.Menu_Credit, Menu_Credit);
    }

    public void OpenMenu(XROSMenuTypes menuTypes)
    {
        foreach (KeyValuePair<XROSMenuTypes, GameObject> item in menus)
        {
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            if (item.Value != null)
            {
                if (item.Key != menuTypes)
                {
                    item.Value.SetActive(false);
                }
                else
                {
                    item.Value.SetActive(true);
                }
            }
            else
            {
                Dev.LogError(item.Key + " does not exist");
            }
        }
    }

    public void OpenMenu(string val)
    {
        XROSMenuTypes currentMenu;
        if (Enum.TryParse(val, true, out currentMenu))
        {
            if (Enum.IsDefined(typeof(XROSMenuTypes), currentMenu) | currentMenu.ToString().Contains(","))
            {
                Console.WriteLine("Converted '{0}' to {1}", val, currentMenu.ToString());

                OpenMenu(currentMenu);
            }
            else
            {
                Console.WriteLine("{0} is not a value of the enum", val);
            }
        }
        else
        {
            Console.WriteLine("{0} is not a member of the enum", val);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DebugInput();
    }
    private void DebugInput()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            OpenMenu("Menu_None");
        }
        if (Input.GetKey(KeyCode.F2))
        {
            OpenMenu("Menu_General");
        }
        if (Input.GetKey(KeyCode.F3))
        {
            OpenMenu("Menu_Setting");
        }
        if (Input.GetKey(KeyCode.F4))
        {
            OpenMenu("Menu_Audio");
        }
        if (Input.GetKey(KeyCode.F5))
        {
            OpenMenu("Menu_Visual");
        }
        if (Input.GetKey(KeyCode.F6))
        {
            OpenMenu("Menu_User");
        }
        if (Input.GetKey(KeyCode.F7))
        {
            OpenMenu("Menu_Screenshot");
        }
        if (Input.GetKey(KeyCode.F8))
        {
            OpenMenu("Menu_Credit");
        }

    }
}
