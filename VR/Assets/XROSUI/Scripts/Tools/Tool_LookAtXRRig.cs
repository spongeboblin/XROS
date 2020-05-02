using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_LookAtXRRig : MonoBehaviour
{
    Transform XRCameraTransform;
    //Only use additional rotation if you can't easily set the right orientation 
    public Vector3 additionalRotation;
    // Start is called before the first frame update
    void Start()
    {
        XRCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.LookAt(XRCameraTransform);
        this.transform.Rotate(this.additionalRotation, Space.Self);
    }
}
