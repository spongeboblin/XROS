using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventHandler_NewUser(string name);

public class Manager_Account : MonoBehaviour
{
    public static event EventHandler_NewUser EVENT_NewUser;
    private string m_UserName = "powenyao";

    public string UserName()
    {
        return m_UserName;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeUserName("johnsmith");   
    }

    public bool CheckAuthentication(string userName)
    {
        if (userName.Equals("powenyao"))
        {
            return true;
        }
        
        return false;
    }
    public void ChangeUserName(string s)
    {
        if (EVENT_NewUser != null)
        {
            EVENT_NewUser(s);
        }
        m_UserName = s;
        Dev.Log("User changed to " + s);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeUserName("TillyChan");
        }
    }
}
