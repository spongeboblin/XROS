using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class VREquipment : MonoBehaviour
{
    protected XRGrabInteractable m_GrabInteractable;
    protected MeshRenderer m_MeshRenderer;

    protected static Color m_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);
    protected static Color m_UnityCyan = new Color(0.019f, 0.733f, 0.827f);

    public bool m_Held = false;
    private bool bInSocket = false;
    float lastHeldTime;

    public float timeBeforeReturn = 0.5f;
    public GameObject socket;
    public XROSMenuTypes menuTypes = XROSMenuTypes.Menu_General;
    Rigidbody m_Rigidbody;
    void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_GrabInteractable.onFirstHoverEnter.AddListener(onFirstHoverEnter);
        m_GrabInteractable.onHoverEnter.AddListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExit.AddListener(OnHoverExit);
        m_GrabInteractable.onSelectEnter.AddListener(OnGrabbed);
        m_GrabInteractable.onSelectExit.AddListener(OnReleased);
        m_GrabInteractable.onActivate.AddListener(OnActivated);
        m_GrabInteractable.onDeactivate.AddListener(OnDeactivated);
    }

    private void OnDisable()
    {
        m_GrabInteractable.onFirstHoverEnter.RemoveListener(onFirstHoverEnter);
        m_GrabInteractable.onHoverEnter.RemoveListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExit.RemoveListener(OnHoverExit);
        m_GrabInteractable.onSelectEnter.RemoveListener(OnGrabbed);
        m_GrabInteractable.onSelectExit.RemoveListener(OnReleased);
        m_GrabInteractable.onActivate.RemoveListener(OnActivated);
        m_GrabInteractable.onDeactivate.RemoveListener(OnDeactivated);
    }

    public virtual void OnActivated(XRBaseInteractor obj)
    {
        //print("Activated " + this.name);
    }
    public virtual void OnDeactivated(XRBaseInteractor obj)
    {
        //print("Deactivated " + this.name);
    }

    private void OnGrabbed(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = m_UnityCyan;
        //print("Grabbed: " + this.name);
        m_Held = true;
        bInSocket = false;
        this.transform.SetParent(null);
    }

    void OnReleased(XRBaseInteractor obj)
    {
        // print("Released");
        m_MeshRenderer.material.color = Color.white;
        m_Held = false;
        m_Rigidbody.ResetCenterOfMass();
        m_Rigidbody.ResetInertiaTensor();
        m_Rigidbody.angularDrag = 0;
        m_Rigidbody.angularVelocity = Vector3.zero;
        //m_Rigidbody.sle1 = 0;
    }

    void OnHoverExit(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = Color.white;
        }
    }

    void onFirstHoverEnter(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            //print("Hover: " + this.name);
            m_MeshRenderer.material.color = m_UnityMagenta;
        }
    }

    void OnHoverEnter(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            //Vibrate
            //foreach(XRBaseInteractor hi in this.m_GrabInteractable.hoveringInteractors)
            //{

            //}
        }
    }

    public virtual void AlternateFunction()
    {
        //Dev.Log("Alternate Function: " + this.name);
        Debug.Log("AlterAddmenu");
    }

    // need to be fixed
    //public virtual void TriggerFunction()
    //{

    //}

    public virtual void HandleGesture(ENUM_XROS_Gesture gesture)
    {

    }

    void Update()
    {
        if (m_Held)
        {
            lastHeldTime = Time.time;
        }
        else if (!m_Held && Time.time > lastHeldTime + timeBeforeReturn)
        {
            if (!bInSocket)
            {
                this.transform.localRotation = Quaternion.identity;
                this.transform.position = socket.transform.position;

                this.transform.SetParent(socket.transform);
                m_Rigidbody.ResetCenterOfMass();
                m_Rigidbody.ResetInertiaTensor();
                m_Rigidbody.angularDrag = 0;
                m_Rigidbody.angularVelocity = Vector3.zero;
                m_Rigidbody.velocity = Vector3.zero;
                this.transform.localRotation = Quaternion.identity;
                this.transform.position = socket.transform.position;

                bInSocket = true;
            }
        }
    }
}
