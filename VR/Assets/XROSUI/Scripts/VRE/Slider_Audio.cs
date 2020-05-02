using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Slider_Audio : MonoBehaviour
{
    public AudioMixer mixer;
    public Audio_Type type;
        
    public void SetVolume(float f)
    {
        Core.Ins.AudioManager.SetVolume(f, type);
    }
}
