/*
 * Idea and code from link:
 * https://www.youtube.com/watch?v=Oadq-IrOazg
 * https://www.youtube.com/watch?v=JS4k_lwmZHk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Animator animationController;
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Heart"))
        VRUserCredential vre = other.GetComponent<VRUserCredential>();
        if (vre)
        {
            if (Core.Ins.Account.CheckAuthentication(vre.Credential))
            {
                animationController.SetBool("fadeOut", true);
                // Debug.Log("fadeOut true");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Heart"))
        VRUserCredential vre = other.GetComponent<VRUserCredential>();
        if (vre)
        {
            if (Core.Ins.Account.CheckAuthentication(vre.Credential))
            {
                animationController.SetBool("fadeOut", false);
                // Debug.Log("fadeOut false");
            }
        }
    }

    public void Teleportation(string name)
    {
        animationController.SetBool("fadeOut", true);
        // Debug.Log("fadeOut true");

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            this.Teleportation("");
        }
    }
}
