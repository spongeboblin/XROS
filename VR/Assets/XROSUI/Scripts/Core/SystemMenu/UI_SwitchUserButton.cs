using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_SwitchUserButton : MonoBehaviour
{
    private string m_HardCodeName1 = "johnsmith";
    private string m_HardCodeName2 = "powenyao";
    private bool bFirstName = true;
    public void SwitchUser()
    {
        if(!bFirstName)
        {
            Core.Ins.Account.ChangeUserName(m_HardCodeName1);
            
        }
        else
        {
            Core.Ins.Account.ChangeUserName(m_HardCodeName2);
        }
        bFirstName = !bFirstName;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
