using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenEquipmentMenu : MonoBehaviour
{
    //Controller_GameMenu gameMenu;
    public void Start()
    {
     //   gameMenu = GameObject.Find("UIParent").GetComponent<Controller_GameMenu>();
    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        //if (other.CompareTag("AlternateFunction"))
        {
            /*if (other.name == " ")
            {
                gameMenu.OpenMenu("Menu_General");
                Debug.Log("Menu_General");
            }
            */
            VREquipment vre = other.GetComponent<VREquipment>();
            if (vre)
            {
                Core.Ins.SystemMenu.Manager.OpenMenu(vre.menuTypes);
      //          gameMenu.OpenMenu(vre.menuTypes);
            }
        }
    }
}
