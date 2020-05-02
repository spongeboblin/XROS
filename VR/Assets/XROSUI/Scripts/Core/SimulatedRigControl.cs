using UnityEngine;
using UnityEngine.XR;
public class SimulatedRigControl : MonoBehaviour
{
    public enum XRDevice { Headset, LController, RController, Area }
    public XRDevice currentDevice = XRDevice.LController;

    //Assigned in Inspector
    public Transform T_Headset;
    public Transform T_LController;
    public Transform T_RController;
    public Transform T_Area;

    public float translationSpeedForControllers = 5f;
    public float rotationSpeed = 30f;
    public Vector3 StartingAreaPosition;
    public Quaternion StartingAreaRotation;

    private void Awake()
    {
        StartingAreaPosition = T_Area.position;
        StartingAreaRotation = T_Area.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void ChangeSimulatedXRDevice(XRDevice xrd)
    {
        currentDevice = xrd;
        print("Controlling: " + currentDevice.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F1))
        {
            EnableXR();
        }
        if (Input.GetKeyUp(KeyCode.F2))
        {
            DisableXR();
        }
        //Change Devices
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            ChangeSimulatedXRDevice(XRDevice.Area);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ChangeSimulatedXRDevice(XRDevice.LController);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ChangeSimulatedXRDevice(XRDevice.RController);
        }
        //Reset Devices
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            T_Area.position = StartingAreaPosition;
            T_Area.rotation = StartingAreaRotation;
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            T_LController.localPosition = Vector3.zero;
            T_LController.localRotation = Quaternion.identity;
            T_RController.localPosition = Vector3.zero;
            T_RController.localRotation = Quaternion.identity;
        }

        //TRANSLATION
        Vector3 tempVector3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            tempVector3 += transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tempVector3 += -transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tempVector3 += transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tempVector3 += -transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.R))
        {
            tempVector3 += transform.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F))
        {
            tempVector3 += -transform.up * Time.deltaTime;
        }
        
        Vector3 rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector += Vector3.up * -rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector += Vector3.up * rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.T))
        {
            rotationVector += Vector3.right * -rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.G))
        {
            rotationVector += Vector3.right * rotationSpeed * Time.deltaTime;
        }

        Quaternion rotX = Quaternion.AngleAxis(rotationVector.x, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(rotationVector.y, Vector3.up);
        Quaternion rotZ = Quaternion.AngleAxis(rotationVector.z, Vector3.forward);

        //TODO Add Speed Adjustment

        if (tempVector3 != Vector3.zero || rotationVector != Vector3.zero)
        {
            ApplyChangesToTransform(currentDevice, tempVector3, rotX, rotY, rotZ);
        }        
    }

    public void ApplyChangesToTransform(XRDevice xrd, Vector3 pos, Quaternion rotX, Quaternion rotY, Quaternion rotZ)
    {
        Transform t = T_Area;
        switch (xrd)
        {
            case XRDevice.Area:
                t = T_Area;
                break;
            case XRDevice.LController:
                t = T_LController;
                break;
            case XRDevice.RController:
                t = T_RController;
                break;
            case XRDevice.Headset:
                t = T_Headset;
                break;
            default:
                break;
        }
        print(pos);
        t.position += pos;
        t.rotation = t.rotation * rotX;
        t.rotation = t.rotation * rotY;
        t.rotation = t.rotation * rotZ;
    }
    /// <summary>
    /// Enables XR in the Unity Software.
    /// </summary>
    public virtual void EnableXR()
    {
        XRSettings.enabled = true;
        print("XR enabled");
    }

    /// <summary>
    /// Disables XR in the Unity Software.
    /// </summary>
    public virtual void DisableXR()
    {
        XRSettings.enabled = false;
        print("XR disabled");
    }
}
