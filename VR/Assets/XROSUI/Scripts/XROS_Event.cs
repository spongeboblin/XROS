using System;

[Serializable]
public class XROS_Event
{
    public TextDisplayType TargetText;
    public string content;
    public bool HasPrerequisite;
    public string prerequisiteFlagId;
    public int secondsToWait;//This event need to be showed for this time to go to the next event.

    private XROS_Event(TextDisplayType type, string text, bool hasPrerequisite, string flagID, int waitTime)//not use anymore
    {

        this.TargetText = type;
        this.content = text;
        this.HasPrerequisite = hasPrerequisite;
        this.prerequisiteFlagId = flagID;
        this.secondsToWait = waitTime;
    }

    //not use anymore
    public static XROS_Event CreateEvent(Controller_Scenario controller, TextDisplayType type, string text, bool hasPrerequisite, string flagID)
    {
        if (controller.AddFlag(flagID))
        {
            return new XROS_Event(type, text, hasPrerequisite, flagID, -1);
        }
        else
        {
            throw new System.Exception("Flag ID has already been taken");
        }
    }

    //not use anymore
    public static XROS_Event CreateEvent(Controller_Scenario controller, TextDisplayType type, string text, int waitTime)
    {
        return new XROS_Event(type, text, false, null, waitTime);
    }
}