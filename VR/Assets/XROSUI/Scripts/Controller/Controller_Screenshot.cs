using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public delegate void EventHandler_NewScreenshot();

public class Controller_Screenshot : MonoBehaviour
{
    public static event EventHandler_NewScreenshot EVENT_NewScreenshot;
    public float DurationToShow = 2.0f;
    public TextMeshProUGUI myButton;
    public GameObject myPanel;
    Texture2D m_Texture;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Broken in Unity?
        //if (Input.GetKey(KeyCode.Print))
        if (Input.GetKeyDown(KeyCode.Pause))
        {
            TakeAShot();
        }
    }

    private string fileName;
    private string pathToSave;
    public void TakeAShot()
    {
        Core.Ins.AudioManager.PlaySfx("360329__inspectorj__camera-shutter-fast-a");
        //Debug.Log("The Screenshot is saved in " + Application.persistentDataPath);
        // "Application.persistentDataPath" is the file path to save the screenshots, you can change it according to your need

        string fileName = "ScreenshotX" + System.DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + ".png";//the screenshot image is name in this format, you can change it according to your need
        pathToSave = Application.persistentDataPath + "/" + fileName;

        ScreenCapture.CaptureScreenshot(pathToSave);
        m_Texture = ScreenCapture.CaptureScreenshotAsTexture();

        if (EVENT_NewScreenshot != null)
        {
            EVENT_NewScreenshot();
        }
        StartCoroutine(ShowAndHide(myPanel, DurationToShow));
    }


    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        myButton.enabled = true;
        myButton.SetText("Screenshot Taken!");
        go.SetActive(true);
        Sprite sp = Sprite.Create(m_Texture, new Rect(0, 0, m_Texture.width, m_Texture.height),
                new Vector2(0.5f, 0.5f));
        Image image = go.GetComponent<Image>();
        image.sprite = sp;
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
        myButton.enabled = false;
    }

    IEnumerator CaptureIt()
    {
        yield return new WaitForEndOfFrame();
        //Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);
    }
}
