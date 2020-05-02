using System;

//Serializable: https://docs.unity3d.com/ScriptReference/Serializable.html

[Serializable]
public class SaveData
{
    public float savedVersion;

    public Controller_Audio.SettingSaveData audioSetting;
    //public ADManager.ClassSaveData adManagerSaveData;
    //public AudioManager.ClassSaveData audioManagerSaveData;
    //public CurrencyManager.ClassSaveData currencyManagerSaveData;
    //public IdleManager.ClassSaveData idleManagerSaveData;
    //public OfflineManager.ClassSaveData offlineManagerSaveData;
    //public StatsManager.ClassSaveData statsManagerSaveData;
}
