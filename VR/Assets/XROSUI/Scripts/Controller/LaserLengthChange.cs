using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class LaserLengthChange : MonoBehaviour
{
    XRGrabInteractable m_GrabInteractable;
    XRRayInteractor LaserFromRay;
    MeshRenderer m_MeshRenderer;
    public GameObject LaserFrom;
    public GameObject LaserFromEmitter;
    public GameObject LaserReceiving;
    public bool grabbed;
    private float priorDistance;
    private float angle;//angle between emitter and controller
    private Vector3 normalVector;// The normal Vector to recover emitter angle after releasing the button.
    private Quaternion LocalRotation;

    static Color m_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);
    static Color m_UnityCyan = new Color(0.019f, 0.733f, 0.827f);

    void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        this.LaserFromRay = LaserFrom.GetComponent<XRRayInteractor>();
        // m_GrabInteractable.onFirstHoverEnter.AddListener(OnHoverEnter);
        // m_GrabInteractable.onLastHoverExit.AddListener(OnHoverExit);
        m_GrabInteractable.onSelectEnter.AddListener(OnGrabbed);
        m_GrabInteractable.onSelectExit.AddListener(OnReleased);
    }

    void OnGrabbed(XRBaseInteractor obj)
    {
        this.grabbed = true;
        priorDistance = Vector3.Distance(LaserFrom.transform.position, LaserReceiving.transform.position);
        this.angle = Vector3.Angle(this.transform.forward, this.LaserReceiving.transform.forward);
        this.normalVector = Vector3.Cross(this.LaserReceiving.transform.forward, this.transform.forward);
        Core.Ins.ScenarioManager.SetFlag("LaserLengthChanged",true);
        // this.LocalRotation=this.LaserFromEmitter.transform.localRotation;
        // print(this.LocalRotation);
    }

    void OnReleased(XRBaseInteractor obj)
    {
        this.grabbed = false;
        // this.LaserFromEmitter.transform.forward=this.LaserFrom.transform.forward;
        // this.LaserFromEmitter.transform.RotateAround(this.transform.position, normalVector, angle);
        // this.LaserFromEmitter.transform.position=this.LaserFrom.transform.position + this.LaserFrom.transform.forward*0.06f;
        // this.LaserFromEmitter.transform.localRotation=this.LocalRotation;
        // print(this.LocalRotation);
    }

    void OnHoverExit(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = Color.white;
    }

    void OnHoverEnter(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = m_UnityMagenta;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.grabbed)
        {
            this.transform.position = this.LaserReceiving.transform.position;//-this.LaserReceiving.transform.forward*0.2f;
            float newDistance = Vector3.Distance(LaserFrom.transform.position, LaserReceiving.transform.position);
            LaserFromRay.maxRaycastDistance = newDistance;
            // LaserFromRay.maxRaycastDistance+=(newDistance-priorDistance);
            Vector3 direction = this.transform.position - LaserFrom.transform.position;
            LaserFromEmitter.transform.forward = direction;
            // priorDistance=newDistance;
        }
    }
}
