using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class Tool_GetWorldSpaceCamera : MonoBehaviour
{
    private Canvas Canvas;

    // Start is called before the first frame update
    void Start()
    {
        //Canvas.worldCamera = GameObject.Find("XRRig_XROS").GetComponent<UnityEngine.XR.Interaction.Toolkit.XRRig>().cameraGameObject.GetComponent<Camera>();
        if(Canvas)
        {
            
        }
        else
        {
            //print("No World Camera assigned to Canvas at " + this.gameObject.name + ". Attempt to auto assignin camera");
            Canvas = this.GetComponent<Canvas>();
        }
        Canvas.worldCamera = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
    }

}
