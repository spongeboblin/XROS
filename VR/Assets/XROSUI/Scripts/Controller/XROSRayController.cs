using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;


public class XROSRayController : MonoBehaviour
{
    LineRenderer m_lineRenderer;
    XRInteractorLineVisual m_XRInteractorLineVisual;
    XRRayInteractor m_RayInteractor;
    public LaserLengthChange grabbedTarget;
    public LaserTracking laserTracker;
    bool grabbing;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        this.m_lineRenderer = this.GetComponent<LineRenderer>();
        this.m_RayInteractor = GetComponent<XRRayInteractor>(); ;
        this.m_XRInteractorLineVisual = this.GetComponent<XRInteractorLineVisual>();
        this.grabbing = false;

        //m_RayInteractor.onHoverEnter
        //m_RayInteractor.onHoverExit
        //m_RayInteractor.onSelectEnter
        //m_RayInteractor.onSelectExit        
    }

    public void OnGrab(/*XRBaseInteractor obj*/)
    {
        if (!this.grabbing)
        {
            this.grabbing = true;
        }
    }

    public void OnRelease(/*XRBaseInteractor obj*/)
    {
        if (this.grabbing)
        {
            this.grabbing = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.grabbing && !grabbedTarget.grabbed && !laserTracker.m_Held)
        {
            // print("onGrab grabbed="+(grabbedTarget.grabbed? "true":"false"));
            // this.lineRenderer.enabled=false;
            if (this.m_XRInteractorLineVisual.enabled)
            {
                this.m_XRInteractorLineVisual.enabled = false;
            }
        }
        else
        {
            if (!this.m_XRInteractorLineVisual.enabled)
            {
                this.m_XRInteractorLineVisual.enabled = true;
            }
        }
    }
}
