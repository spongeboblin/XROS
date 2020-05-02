using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionToggler : MonoBehaviour
{//This class is used to make enter/exit behave like toggle.

    public bool InitalState;
    public UnityEvent TurnedOn;
    public UnityEvent TurnedOff;
    bool state;

    // Start is called before the first frame update
    void Start()
    {
        state = InitalState;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Trigger()
    {
        state = !state;
        if (state)
        {
            TurnedOn.Invoke();
            print("LightTurnOn");
        }
        else
        {
            TurnedOff.Invoke();
        }
    }
}
