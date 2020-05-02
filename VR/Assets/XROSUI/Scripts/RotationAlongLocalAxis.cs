
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAlongLocalAxis : MonoBehaviour
{
    public GameObject GO_XRRigCamera;
    public bool bFollows;
    public float offset_x = 1f;
    public float offset_y = 0.1f;
    public float offset_z = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //Canvas.worldCamera = GameObject.Find("XRRig_XROS").GetComponent<UnityEngine.XR.Interaction.Toolkit.XRRig>().cameraGameObject.GetComponent<Camera>();        
        GO_XRRigCamera = Camera.main.gameObject;

        FollowCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (bFollows)
        {
            FollowCamera();
        }
    }

    void FollowCamera()
    {
        //this.transform.rotation = GO_XRRigCamera.transform.rotation;
    }
}
