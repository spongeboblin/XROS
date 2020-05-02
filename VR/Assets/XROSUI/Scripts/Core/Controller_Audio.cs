﻿using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

//Supported Audio Formats
//https://docs.unity3d.com/Manual/AudioFiles.html
public enum Audio_Type { master, voice, music, sfx }

public delegate void EventHandler_NewMasterVolume(float newValue);

//Design Note:
//a_source is used for basic system UI sound effects (such as error)
//musice_source is used for music.
//Every other sound effect would be requested and created through an object pooler.
public class Controller_Audio : MonoBehaviour
{
    public static event EventHandler_NewMasterVolume EVENT_NewMasterVolume;

    public AudioMixer mixer;
    float musicVol;
    //public Text text;
    Text Text_volumeValue;
    //Public so we can drag child objects
    public AudioSource AudioSource_Master;
    [Tooltip("Drag child object with an audiosource to be used as the default menu sfx audio source")]
    public AudioSource AudioSource_SFX;
    [Tooltip("Drag child object with an audiosource to be used as the default music source")]
    public AudioSource AudioSource_Music;
    //[Tooltip("Drag child object with an audiosource to be used as the default music source")]
    public AudioSource AudioSource_Voice;
    [Tooltip("Drag an audio file to be the default error sound")]
    public AudioClip AudioClip_Error;
    [Tooltip("Drag a GO_AudioSource Prefab to be used for all audio effects, through ObjectPooling")]
    public GO_AudioSource PF_AudioSource;

    //Tracks the different clips we have loaded
    Dictionary<string, AudioClip> audioDictionary = new Dictionary<string, AudioClip>();

    //Class Save Data
    [HideInInspector]
    public SettingSaveData Setting;

    void Start()
    {
    }

    private void Awake()
    {
        PF_AudioSource.gameObject.SetActive(false);

        LoadAudioClip("ClickFeedback", "dumdum");
    }

    public void PlaySound(AudioClip clip)
    {
        GO_AudioSource obj = Instantiate(PF_AudioSource, transform);
        obj.PlaySound(clip);
    }

    #region OnSceneLoaded
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Reference
    //https://forum.unity.com/threads/how-to-use-scenemanager-onsceneloaded.399221/
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Dev.Log("Scene Name: " + scene.name + " build index " + scene.buildIndex, Dev.LogCategory.Audio);
        AudioClip newLevelMusicClip;
        if (scene.buildIndex == 0)
        {
            newLevelMusicClip = LoadAudioClip("Land of Knights (Long Loop)");
        }
        else
        {
            newLevelMusicClip = LoadAudioClip("Dreamland (Loop)");
        }

        Dev.Log("Playing Music: " + newLevelMusicClip.name, Dev.LogCategory.Audio);

        if (newLevelMusicClip)
        {
            AudioSource_Music.clip = newLevelMusicClip;
            AudioSource_Music.loop = true;
            AudioSource_Music.Play();
        }
    }
    #endregion OnSceneLoaded

    #region Play Audio
    public void PlayPauseMusic()
    {
        if (AudioSource_Music.isPlaying)
        {
            AudioSource_Music.Pause();
        }
        else
        {
            AudioSource_Music.UnPause();
        }
    }
    public void PlayMaster(string acname)
    {
        this.PlayMaster(LoadAudioClip(acname));
    }

    public void PlayMaster(AudioClip ac)
    {
        //Make sure we have a valid clip
        if (ac == null) return;

        AudioSource source = this.AudioSource_Master;
        source.clip = ac;
        source.Play();
    }

    public void PlayMusic(string acname)
    {
        this.PlayMusic(LoadAudioClip(acname));
    }

    public void PlayMusic(AudioClip ac)
    {
        //Make sure we have a valid clip
        if (ac == null) return;
        AudioSource source = this.AudioSource_Music;
        AudioSource_Music.loop = true;
        source.clip = ac;
        source.Play();
    }
    public void PlaySfx(string acname)
    {
        this.PlaySfx(LoadAudioClip(acname));
    }

    public void PlaySfx(AudioClip ac)
    {
        //Make sure we have a valid clip
        if (ac == null) return;


        AudioSource source = this.AudioSource_SFX;
        source.clip = ac;
        source.Play();
    }
    public void PlayVoice(string acname)
    {
        this.PlayVoice(LoadAudioClip(acname));
    }

    public void PlayVoice(AudioClip ac)
    {
        //Make sure we have a valid clip
        if (ac == null) return;


        AudioSource source = this.AudioSource_Voice;
        source.clip = ac;
        source.Play();
    }

    private void Play3DAudio(AudioClip ac, GameObject go, float pitch = 1f)
    {
        //Make sure we have a valid clip
        if (ac == null) return;

        //Handles pitch variation
        if (pitch != 1)
        {
            pitch = UnityEngine.Random.Range(1 - pitch, 1 + pitch);
        }

        //TODO ObjectPooling
        //GameObject audioObj = PoolManager.Spawn(instance.oneShotPrefab, position, Quaternion.identity);
        //AudioSource source = audioObj.GetComponent<AudioSource>();
        AudioSource source = this.AudioSource_SFX;

        source.clip = ac;
        source.pitch = pitch;
        source.Play();

        //deactivate audio gameobject when the clip stops playing
        //PoolManager.Despawn(audioObj, clip.length);
    }

    public void Play3DAudio(string acname, GameObject go)
    {
        this.Play3DAudio(LoadAudioClip(acname), go);
    }

    public void Play2DAudio(string acname)
    {
        this.Play3DAudio(LoadAudioClip(acname), this.gameObject);
    }
    #endregion Play Audio

    #region Load Audio
    /// <summary>
    /// Loads an Audio Clip based on the resourcename, calls the other LoadAudioClip to handle the request.
    /// </summary>
    /// <param name="resourcename"></param>
    /// <returns></returns>
    private AudioClip LoadAudioClip(string resourcename)
    {
        return LoadAudioClip(resourcename, resourcename);
    }

    /// <summary>
    /// Loads an audio into the audioDictionary based on resourcename, if it hasn't been loaded
    /// </summary>
    /// <param name="name"></param>
    /// <param name="resourcename"></param>
    /// <returns></returns>
    private AudioClip LoadAudioClip(string name, string resourcename)
    {
        AudioClip ac;
        if (audioDictionary.ContainsKey(name))
        {
            ac = audioDictionary[name];
        }
        else
        {
            ac = Resources.Load<AudioClip>(resourcename);
            if (ac != null)
            {
                Dev.Log(name + " not in dictionary, loading " + resourcename + " in Resources folder", Dev.LogCategory.Audio);
                audioDictionary.Add(name, ac);
            }
            else
            {
                Dev.Log(name + " not in dictionary and " + resourcename + " not in Resources folder. Default to error clip", Dev.LogCategory.Audio);
                //Note: To Address this issue, make sure the audio with the name you want to use is loaded into the audioDictionary.
                audioDictionary.Add(name, AudioClip_Error);
                ac = AudioClip_Error;
            }
        }

        return ac;
    }
    #endregion Load Audio

    #region Setting Save Data
    [Serializable]
    public struct SettingSaveData
    {
        public bool soundOn;
        public bool musicOn;
    }

    public SettingSaveData DefaultSaveData()
    {
        SettingSaveData saveData = new SettingSaveData
        {
            soundOn = true,
            musicOn = true,
        };
        return saveData;
    }

    public SettingSaveData GetSaveData()
    {
        return Setting;
    }

    public void LoadSaveData(SaveData saveData)
    {
        Setting = saveData.audioSetting;
    }

    /*
     * public void ShowVolumeValue(float f, AudioMixer mixer)
    {
        mixer.GetFloat("MusicVol", out musicVol);
        Debug.Log("MusicVol:"+musicVol);
        Text_volumeValue.text = "Volume:" + ((int)(f* 100)).ToString() + "%";
    }
    */

    public void AdjustVolume(float f, Audio_Type type)
    {
        float newVolume = 0f;
        switch (type)
        {
            //TODO fix different type
            case Audio_Type.master:
                mixer.GetFloat("MasterVolume", out newVolume);
                //Debug.Log("MasterVolume:" + newVolume);
                f += Mathf.Pow(10f, newVolume / 20f);
                break;
            case Audio_Type.music:
                mixer.GetFloat("MusicVolume", out newVolume);
                Debug.Log("MusicVolume:" + newVolume);
                f += Mathf.Pow(10f, newVolume / 20f);
                break;
            case Audio_Type.voice:
                mixer.GetFloat("VoiceVolume", out newVolume);
                Debug.Log("VoiceVolume:" + newVolume);
                f += Mathf.Pow(10f, newVolume / 20f);
                break;
            case Audio_Type.sfx:
                mixer.GetFloat("SFXVolume", out newVolume);
                Debug.Log("SFXVolume:" + newVolume);
                f += Mathf.Pow(10f, newVolume / 20f);
                break;
            default:
                break;
        };
        //Dev.Log("New Volume: " + f);
        //print("New Volume: " + f);
        SetVolume(f, type);

    }

    public float GetVolume(Audio_Type type)
    {
        float newVolume = 0f;
        switch (type)
        {
            case Audio_Type.master:
                mixer.GetFloat("MasterVolume", out newVolume);
                Debug.Log("MasterVolume:" + newVolume);
                break;
            case Audio_Type.music:
                mixer.GetFloat("MusicVolume", out newVolume);
                Debug.Log("MusicVolume:" + newVolume);
                break;
            case Audio_Type.voice:
                mixer.GetFloat("VoiceVolume", out newVolume);
                Debug.Log("VoiceVolume:" + newVolume);
                break;
            case Audio_Type.sfx:
                mixer.GetFloat("SFXVolume", out newVolume);
                Debug.Log("SFXVolume:" + newVolume);
                break;
            default:
                break;
        };
        return newVolume;
    }
    public void SetVolume(float f, Audio_Type type)
    {
        if (f > 1)
        {
            f = 1;
        }
        else if (f < 0)
        {
            f = 0;
        }

        switch (type)
        {
            //TODO
            case Audio_Type.master:
                if (EVENT_NewMasterVolume != null)
                {
                    EVENT_NewMasterVolume(f);
                }
                f = Mathf.Log10(f) * 20;
                mixer.SetFloat("MasterVolume", f);
                break;
            case Audio_Type.music:
                if (EVENT_NewMasterVolume != null)
                {
                    EVENT_NewMasterVolume(f);
                }
                f = Mathf.Log10(f) * 20;
                mixer.SetFloat("MusicVolume", f);
                break;
            case Audio_Type.voice:
                if (EVENT_NewMasterVolume != null)
                {
                    EVENT_NewMasterVolume(f);
                }
                f = Mathf.Log10(f) * 20;
                mixer.SetFloat("VoiceVolume", f);
                break;
            case Audio_Type.sfx:
                if (EVENT_NewMasterVolume != null)
                {
                    EVENT_NewMasterVolume(f);
                }
                f = Mathf.Log10(f) * 20;
                mixer.SetFloat("SFXVolume", f);
                break;
            default:
                break;

        }
    }
    #endregion
}
