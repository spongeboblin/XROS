using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class LaserEmitterPositionRetainer : MonoBehaviour
{

    XRGrabInteractable m_GrabInteractable;
    MeshRenderer m_MeshRenderer;
    
    public GameObject selfController;
    public GameObject secondController;
    public LaserTracking laserTracker;
    public LaserLengthChange target;
    // public GameObject Emitter;

    Vector3 priorDirection;

    Vector3 normalVector;
    Quaternion localRotation;
    float angle;

    static Color m_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);
    static Color m_UnityCyan = new Color(0.019f, 0.733f, 0.827f);

    bool m_Held = false;

    void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        
        m_GrabInteractable.onFirstHoverEnter.AddListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExit.AddListener(OnHoverExit);
        m_GrabInteractable.onSelectEnter.AddListener(OnGrabbed);
        m_GrabInteractable.onSelectExit.AddListener(OnReleased);
    }

    
    private void OnDisable()
    {
        m_GrabInteractable.onFirstHoverEnter.RemoveListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExit.RemoveListener(OnHoverExit);
        m_GrabInteractable.onSelectEnter.RemoveListener(OnGrabbed);
        m_GrabInteractable.onSelectExit.RemoveListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = m_UnityCyan;
        m_Held = true;
        Core.Ins.ScenarioManager.SetFlag("EmitterGrabbed",true);
        // this.priorDirection=this.secondController.transform.forward;
        this.priorDirection=(this.secondController.transform.position-this.transform.position).normalized;
        // InvokeRepeating("positionRetainer",0,0.005f);//Works
    }
    
    public void onGrabingObject(){//change the direction of laser 
        // this.angle = Vector3.Angle(this.selfController.transform.forward, this.transform.forward);
        // this.normalVector = Vector3.Cross(this.selfController.transform.forward, this.transform.forward);
        // this.transform.forward=this.selfController.transform.forward;
        if(!this.laserTracker.m_Held){
            this.localRotation=this.transform.localRotation;
            this.transform.rotation=new Quaternion(0f,0f,0f,0f);
        }
    }

    public void onReleasingObject()//go back to the direction of laser  before grabbing stuff.
    {
        // this.transform.RotateAround(this.transform.position, normalVector, angle);
        if(!this.laserTracker.m_Held){
            this.transform.localRotation=this.localRotation;
        }
    }

    void OnReleased(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = Color.white;
        m_Held = false;
        // CancelInvoke();
    }
    

    void OnHoverExit(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = Color.white;
        }
    }

    void OnHoverEnter(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = m_UnityMagenta;
        }
    }


    void positionRetainer(){
        if(m_Held)
        {
            // print("grabbing " + Time.time);
            this.transform.position=this.selfController.transform.position + this.selfController.transform.forward*0.06f;
            Vector3 newDirection=(secondController.transform.position-this.transform.position).normalized;
            Vector3 normalVector=Vector3.Cross(newDirection,this.priorDirection);
            this.transform.RotateAround(this.transform.position,normalVector,-Vector3.Angle(priorDirection,newDirection));
            priorDirection=newDirection;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        if(m_Held) 
        {
            // print("grabbing " + Time.time);
            this.positionRetainer();
        }
    }
}
