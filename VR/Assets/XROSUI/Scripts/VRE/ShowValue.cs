using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class is for subscribing and displaying a particular value.
///It subscribes a value through the use of C# events.
///To use this:
///1. create a script that inherit this script
///2. In the Start method, subscribes to the event by providing the HandleValueChange delegate
///3. In FormatValue, format the float value appropriately with the previous and the next string.
///4. Make sure the appropriate GOs are added to the TrackedGOs List so that they are shown and hidden appropriately
///Since it hides by disabling the GameObject, the script should be in the node above whatever it is trying to show or hide.
/// </summary>
public class ShowValue : MonoBehaviour
{
    //Keeps track of a 
    public List<GameObject> TrackedGOs;
    public TMP_Text m_Text;
    protected float value;
    public float coolDown = 1.0f;
    protected float lastAskTime = 0;
    //Tracks whether 
    protected bool bShow = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (!m_Text)
        {
            m_Text = GetComponentInChildren<TMP_Text>();
        }
        ShowOrHideValues();
    }

    public void HandleValueChange(float f)
    {
        m_Text.text = FormatValue(f);

        this.lastAskTime = Time.time;
        this.bShow = true;
        ShowOrHideValues();
    }
    protected virtual string FormatValue(float f)
    {
        return "Brightness:" + ((int)(f * 100f)).ToString() + "%";
    }

    public virtual void ShowOrHideValues()
    {
        foreach (GameObject go in TrackedGOs)
        {
            go.SetActive(bShow);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if a certain amount of time has passed,, hide myText
        HideAfterDelay();
        //this.m_Text.enabled()
    }

    void HideAfterDelay()
    {
        if (bShow)
        {
            if (lastAskTime + coolDown < Time.time)
            {
                bShow = false;
                ShowOrHideValues();
            }
        }
    }
}
