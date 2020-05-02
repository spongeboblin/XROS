using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text_ShowXROSInput : MonoBehaviour
{
    string compiledMessages = "";
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        if (!text)
        {
            text = this.GetComponent<TMP_Text>();
        }
        XROSInput.EVENT_NewInput += CompileMessage;
        XROSInput.EVENT_NewRemoveInput += RemoveMessage;
        XROSInput.EVENT_NewBackspace += Backspace;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            text.text = "";
            compiledMessages = "";
        }
    }
    public void CompileMessage(string s)
    {
        compiledMessages += s;
        text.text = compiledMessages;
    }

    public void RemoveMessage()
    {
        compiledMessages = "";
        text.text = compiledMessages;
    }

    public void Backspace()
    {
        if (compiledMessages.Length == 0)
        {
            return;
        }
        compiledMessages = compiledMessages.Substring(0, compiledMessages.Length - 1);
        text.text = compiledMessages;
    }
}