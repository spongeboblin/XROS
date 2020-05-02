using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class EventInteractionForSwitch : MonoBehaviour
{
    XRGrabInteractable m_GrabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_GrabInteractable.onSelectEnter.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        m_GrabInteractable.onSelectEnter.RemoveListener(OnGrabbed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGrabbed(XRBaseInteractor obj)
    {
        Core.Ins.ScenarioManager.SetFlag("SwitchGrabbed",true);
    }
    
}
