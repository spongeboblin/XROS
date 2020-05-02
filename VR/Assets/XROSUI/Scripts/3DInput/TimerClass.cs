using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TMPro;

public class TimerClass : MonoBehaviour
{
    //public static string targetText = "barbara had been waiting at the table for twenty minutes";
    public static string targetText = "barbara had been waiting";
    float startTime;
    float currentTime;
    public Text Text_Timer;
    public Button Button_Timer;
    public Text Text_Button_Timer;
    //public TMP_Text testTarget;
    public GameObject testTarget;
    public TMP_Text content;
    public TMP_Text myInputContent;
    bool btimerStarted = false;
    TMP_TextInfo textInfo;
    Color32 m_color;
    Color32[] newVertexColors;
    int old_length;
    int currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        myInputContent.text = "";
        Text_Button_Timer.text = "Start";
        content.color = Color.black;
        content.outlineWidth = 0.15f;
        content.outlineColor = Color.red;
        textInfo = content.textInfo;
        m_color = content.color;
        old_length = 0;
        currentCharacter = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (btimerStarted)
        {
            currentTime += Time.deltaTime;
            Text_Timer.text = currentTime.ToString("0.0");
        }
        else
        {
            Text_Button_Timer.text = "start";
        }

        if (myInputContent.text.Length >= 1)
        {
            currentCharacter = myInputContent.text.Length - 1;
            if (currentCharacter < 0 || currentCharacter >= textInfo.characterInfo.Length)
                return;
            int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;
            int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

            if (old_length > myInputContent.text.Length)
            {
                vertexIndex = textInfo.characterInfo[old_length - 1].vertexIndex;
                newVertexColors[vertexIndex + 0] = m_color;
                newVertexColors[vertexIndex + 1] = m_color;
                newVertexColors[vertexIndex + 2] = m_color;
                newVertexColors[vertexIndex + 3] = m_color;
                old_length = myInputContent.text.Length;
                return;
            }
            old_length = myInputContent.text.Length;

            if (string.Compare(myInputContent.text, targetText.Substring(0, myInputContent.text.Length)) == 0)
            {

                newVertexColors[vertexIndex + 0] = Color.cyan;
                newVertexColors[vertexIndex + 1] = Color.cyan;
                newVertexColors[vertexIndex + 2] = Color.cyan;
                newVertexColors[vertexIndex + 3] = Color.cyan;
                content.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }
            else
            {
                newVertexColors[vertexIndex + 0] = Color.red;
                newVertexColors[vertexIndex + 1] = Color.red;
                newVertexColors[vertexIndex + 2] = Color.red;
                newVertexColors[vertexIndex + 3] = Color.red;
                content.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }
        }
    }

    public void SetTimer()
    {
        if (!btimerStarted)
        {
            testTarget.SetActive(true);
            btimerStarted = true;
            startTime = 0;
            currentTime = startTime;
            content.text = targetText;
            myInputContent.text = ""; // clear up input to start trial
            XROSInput.RemoveInput();
        }
        else
        {
            //testTarget.SetActive(false);
            btimerStarted = false;
            CalculateSpeed(currentTime);
            startTime = 0;
            currentTime = startTime;
            myInputContent.text = ""; // clear up input for next trial
            XROSInput.RemoveInput();
        }
    }

    void CalculateSpeed(float time)
    {
        float wordsPerMinute = 0;
        int numWords = myInputContent.text.Trim().Split(' ').Length;
        wordsPerMinute = numWords / (time / 60);
        int numCharacters = myInputContent.text.ToCharArray().Length;
        content.text = "You finished in " + time + " seconds" +
            "\nYour input speed is " + wordsPerMinute + " words per minute" + "\n" + numCharacters + " characters per minute";

        Core.Ins.ScenarioManager.SetFlag("CalculateSpeed", true);
    }
}
