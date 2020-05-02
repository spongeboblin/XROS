using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_SystemMenu : MonoBehaviour
{
    //public GameObject PF_SystemMenu;

    public GameObject GO_SystemMenu;
    public Controller_GameMenu Manager; 
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("UIParent").GetComponent<Controller_GameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
