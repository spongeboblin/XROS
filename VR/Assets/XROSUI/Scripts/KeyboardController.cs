using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI; //create public inputfield 

public class KeyboardController : MonoBehaviour
{
    public InputField inputField;
    public bool isHovering = false;
    bool isWaiting;
    // Start is called before the first frame update
    void Start()
    {
        isWaiting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterInput(string s)
    {
        int length = inputField.text.Length;
        if (length >= 18)
        {
            inputField.text = inputField.text.Substring(1, length - 1);
        }
        inputField.text += s;
    }

    public void wait()
    {
        isWaiting = true;
    }
    public bool  getWaiting()
    {
        return isWaiting;
    }
    public void SetWaiting()
    {
        StartCoroutine("WaitAndPrint");
        
    }
    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.2f);
        isWaiting = !isWaiting;
    }
}

