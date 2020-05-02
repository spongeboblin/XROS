using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_AudioRecorder : MonoBehaviour
{
    private AudioSource debugAudioSource;
    string[] RecordingDevices;
    int currentDeviceId;

    // Start is called before the first frame update
    public void LoadDevices()
    {
        RecordingDevices = Microphone.devices;
        foreach (string s in RecordingDevices)
        {
            print(s);
        }
    }
    public void SetDevice(int i)
    {
        if (i < 0)
        {
            i = 0;
        }
        else if(i> RecordingDevices.Length)
        {
            i = RecordingDevices.Length - 1;
        }

        currentDeviceId = i;
    }

    void Start()
    {
        debugAudioSource = GetComponent<AudioSource>();
        this.LoadDevices();

        //Core.Ins.AudioManager.PlayPauseMusic();
        //audioSource.clip = Microphone.Start(list[0], true, 10, 44100);
        debugAudioSource.clip = Microphone.Start("", true, 5, 44100);
        debugAudioSource.Play();
    }
    public void StartRecording()
    {

    }
    public void StopRecording()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //debugAudioSource.clip = Microphone.Start(RecordingDevices[this.currentDeviceId], true, 3, 44100);
            debugAudioSource.clip = Microphone.Start(RecordingDevices[this.currentDeviceId], false, 3, 44100);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            debugAudioSource.Play();
        }
    }
}
