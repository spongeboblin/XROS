using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VRUserCredential : VREquipment
{
    public string Credential;
    public TMP_Text Text_UserName;
    // Start is called before the first frame update
    void Awake()
    {
        Manager_Account.EVENT_NewUser += UpdateUser;
    }

    private void Start()
    {
        Text_UserName.text = Core.Ins.Account.UserName();
    }

    public void UpdateUser(string name)
    {
        Text_UserName.text = name;
        Credential = name;
    }
}
