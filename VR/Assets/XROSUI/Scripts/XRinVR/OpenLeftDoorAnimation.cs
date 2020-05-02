/*
 * Idea and code used from link:
 * https://www.youtube.com/watch?v=JS4k_lwmZHk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OpenLeftDoorAnimation : MonoBehaviour
{
    public Animator animationController;
    public Animator animationController2;
    public TMP_Text Text_Authentication;
    public MeshRenderer m_renderer;
    public Material Mat_Warning;
    public Material Mat_Success;
    public Material Mat_Normal;
    private void Start()
    {
        m_renderer = this.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {

        //if (other.CompareTag("Heart"))
        VRUserCredential vre = other.GetComponent<VRUserCredential>();
        if (vre)
        {
            if (Core.Ins.Account.CheckAuthentication(vre.Credential))
            {
                OpenDoor();
            }
            else
            {
                Text_Authentication.text = "Authentication failed. " + vre.Credential + " is not authorized!";
                Core.Ins.AudioManager.PlaySfx("467882__samsterbirdies__beep-warning");

                ChangeMaterial(Color.red);
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
                animationController.SetBool("openLeftDoor", false);
            }
        }
    }

    float lastChangedTime;
    public float duration = 1;
    private bool bMaterialChanged = false;
    private void ChangeMaterial(Color c)
    {
        //print("Change to: " + mat.name);
        lastChangedTime = Time.time;
        //m_renderer.materials[0] = mat;// new Material[1] {mat};        
        //m_renderer.materials[0] = Mat_Warning;// new Material[1] {mat};
        m_renderer.material.color = c;
        bMaterialChanged = true;
    }
    private void OpenDoor()
    {
        animationController.SetBool("openLeftDoor", true);
        animationController2.SetBool("openRightDoor", true);
        Core.Ins.ScenarioManager.SetFlag("OpenDoor", true);//tell the Core you are openning the door.
        Text_Authentication.text = "Authentication successful. Welcome " + Core.Ins.Account.UserName();
        Core.Ins.AudioManager.PlaySfx("511484__mattleschuck__success-bell");
        ChangeMaterial(Color.green);
        // Debug.Log("openLeftDoor");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animationController.SetBool("openLeftDoor", false);
            animationController2.SetBool("openRightDoor", false);
        }
        if (bMaterialChanged && lastChangedTime + duration > Time.time)
        {
            m_renderer.material = Mat_Normal;
            bMaterialChanged = false;
        }
    }
}
