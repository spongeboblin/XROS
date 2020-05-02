using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Controller_XR : MonoBehaviour
{
    GameObject XRRig;
    Camera XrCamera;
    GameObject leftController;
    GameObject rightController;
    GameObject leftRayController;
    GameObject leftDirectController;
    GameObject leftTeleportController;
    GameObject rightRayController;
    GameObject rightDirectController;
    GameObject rightTeleportController;

    // Start is called before the first frame update
    void Start()
    {
        //These are fail safes in case no one registered and no one dragged
        if (!XrCamera)
        {
            //Dev.LogError("No XR Camera registered, attempting to substitute with main camera");
            XrCamera = Camera.main;
        }
        if (!XRRig)
        {
            //Dev.LogError("No XRRIG registered, attempting to substitute with XRRIG_XROS");
            XRRig = GameObject.Find("XRRig_XROS");
            if (!XRRig)
            {
                Dev.LogError("Cannot find XRRIG_XROS");
            }
            else
            {
                ControllerManager_XROS controllerManager_XROS = XRRig.GetComponent<ControllerManager_XROS>();
                leftRayController = controllerManager_XROS.leftBaseController;
                leftDirectController = controllerManager_XROS.leftDirectController;
                leftTeleportController = controllerManager_XROS.leftTeleportController;
                rightRayController = controllerManager_XROS.rightRayController;
                rightDirectController = controllerManager_XROS.rightBaseController;
                rightTeleportController = controllerManager_XROS.rightTeleportController;
            }
        }

        if (!leftRayController)
            leftRayController = GameObject.Find("LeftRayController");
        if (!leftDirectController)
            leftDirectController = GameObject.Find("LeftDirectConroller");
        if (!leftTeleportController)
            leftTeleportController = GameObject.Find("LeftTeleportController");
        if (!rightRayController)
            rightRayController = GameObject.Find("RightRayController");
        if (!rightDirectController)
            rightDirectController = GameObject.Find("RightDirectController");
        if (!rightTeleportController)
            rightTeleportController = GameObject.Find("RightTeleportController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            print(UnityEngine.XR.XRSettings.loadedDeviceName);
            List<InputDevice> list = new List<InputDevice>();
            InputDevices.GetDevices(list);

            print(list.Count);
            foreach (InputDevice i in list)
            {
                print(i.name);
            }
            //print(list.ToString());
        }
    }

    public Camera GetCamera()
    {
        return XrCamera;
    }

    public GameObject GetXRRig()
    {
        return XRRig;
    }

    public GameObject GetLeftRayController()
    {
        return leftRayController;
    }

    public GameObject GetLeftDirectController()
    {
        return leftDirectController;
    }

    public GameObject GetLeftTeleportController()
    {
        return leftTeleportController;
    }

    public GameObject GetRightRayController()
    {
        return rightRayController;
    }

    public GameObject GetRightDirectController()
    {
        return rightDirectController;
    }

    public GameObject GetRightTeleportController()
    {
        return rightTeleportController;
    }


    public void RegisterCamera(Camera camera)
    {
        XrCamera = camera;
    }

    public void RegisterXRRig(GameObject go)
    {
        XRRig = go;
    }
}
