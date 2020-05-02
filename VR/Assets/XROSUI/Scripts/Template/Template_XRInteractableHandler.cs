using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//References: XRITK's ComplexCube, BubbleGun
//References: VRBeginner
//References: XROSUI's VREquipment, KeyboardSetter
[RequireComponent(typeof(XRGrabInteractable))]
public class Template_XRInteractableHandler : MonoBehaviour
{
    XRGrabInteractable m_GrabInteractable;
    MeshRenderer m_MeshRenderer;

    void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();

        //m_GrabInteractable.onActivate.AddListener(OnActivate);
        //m_GrabInteractable.onDeactivate.AddListener(OnDeactivate);
        //m_GrabInteractable.onFirstHoverEnter.AddListener(OnFirstHoverEnter);
        //m_GrabInteractable.onHoverEnter.AddListener(OnHoverEnter);
        //m_GrabInteractable.onHoverExit.AddListener(OnHoverExit);
        //m_GrabInteractable.onLastHoverExit.AddListener(OnLastHoverExit);
        //m_GrabInteractable.onSelectEnter.AddListener(OnSelectEnter);
        //m_GrabInteractable.onSelectExit.AddListener(OnSelectExit);
    }

    //private void OnDisable()
    //{
    //    m_GrabInteractable.onActivate.RemoveListener(OnActivate);
    //    m_GrabInteractable.onDeactivate.RemoveListener(OnDeactivate);
    //    m_GrabInteractable.onFirstHoverEnter.RemoveListener(OnFirstHoverEnter);
    //    m_GrabInteractable.onHoverEnter.RemoveListener(OnHoverEnter);
    //    m_GrabInteractable.onHoverExit.RemoveListener(OnHoverExit);
    //    m_GrabInteractable.onLastHoverExit.RemoveListener(OnLastHoverExit);
    //    m_GrabInteractable.onSelectEnter.RemoveListener(OnSelectEnter);
    //    m_GrabInteractable.onSelectExit.RemoveListener(OnSelectExit);
    //}
    //private void OnActivate(XRBaseInteractor obj)
    //{
    //}
    //private void OnDeactivate(XRBaseInteractor obj)
    //{
    //}
    //private void OnFirstHoverEnter(XRBaseInteractor obj)
    //{
    //}
    //private void OnHoverEnter(XRBaseInteractor obj)
    //{
    //}
    //private void OnHoverExit(XRBaseInteractor obj)
    //{
    //}
    //private void OnLastHoverExit(XRBaseInteractor obj)
    //{
    //}
    //private void OnSelectEnter(XRBaseInteractor obj)
    //{
    //}
    //private void OnSelectExit(XRBaseInteractor obj)
    //{
    //}
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
