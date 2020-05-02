using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEngine.XR.Interaction.Toolkit
{ 
public class colorchange : MonoBehaviour
{
    public Material greenMaterial = null;
    public Material pinkMaterial = null;
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;
       
    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable= GetComponent<XRGrabInteractable>();

        grabInteractable.onActivate.AddListener(SetPink);
        grabInteractable.onDeactivate.AddListener(SetGreen);
    }
    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(SetPink);
        grabInteractable.onDeactivate.RemoveListener(SetGreen);
    }
    private void SetGreen(XRBaseInteractor interactor)
    {
        meshRenderer.material = greenMaterial;
    }
    private void SetPink(XRBaseInteractor interactor)
    {
        meshRenderer.material = pinkMaterial;
    }
}
}