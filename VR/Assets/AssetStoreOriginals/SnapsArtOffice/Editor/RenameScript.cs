using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;



public class RenameScript : EditorWindow
{

    public enum RenameType
    {
        SceneNameOnly,
        AssetPathOnly,
        Both
    }
     


    string sourceString = string.Empty;
    string targetString = string.Empty;

    string prefixString = string.Empty;
    string postfixString = string.Empty;

    string inputString = string.Empty;
    string outputString = string.Empty;

    string inputAssetPath = string.Empty;
    string tempAssetPath = string.Empty;
    string outputAssetPath = string.Empty;


    [MenuItem("AssetStore Tools/Rename object")]
    public static void RunRenamingWin()
    {
        EditorWindow window = GetWindow<RenameScript>();

        window.titleContent.text = "Rename objects";

        window.minSize = new Vector2(400, 400);
        window.maxSize = new Vector2(400, 400);


        window.Show();
    }

    public void renameObjects(bool applyActually, RenameType renameType)
    {
        string tempHtmPath = Path.Combine(Application.persistentDataPath, "renamed.htm");

        if (File.Exists(tempHtmPath))
            File.Delete(tempHtmPath);

        string[] renameLogs = new string[Selection.gameObjects.Length+2];

        renameLogs[0] = "<br>Renamed GameObjects</br>";
        
        for (int i=0;i<Selection.gameObjects.Length;i++)
        {
            string finalOutputString = string.Empty;
            string finalOutputAssetPath = string.Empty;

            if (Selection.gameObjects[i].name == null)
                continue;

            

            inputString = Selection.gameObjects[i].name;

            inputAssetPath = AssetDatabase.GetAssetPath(Selection.objects[i].GetInstanceID());

            if (string.IsNullOrEmpty(inputAssetPath))
                renameType = RenameType.SceneNameOnly;

            tempAssetPath = Path.GetFileName(inputAssetPath);

            //UnityEngine.Debug.Log(tempAssetPath);


            if (!string.IsNullOrEmpty(sourceString))
            {
                finalOutputString = inputString.Replace(sourceString, targetString);
                outputAssetPath = tempAssetPath.Replace(sourceString, targetString);
            }
            else
            {
                finalOutputString = inputString;
                outputAssetPath = tempAssetPath;
            }

            finalOutputString = prefixString + finalOutputString;
            finalOutputString = finalOutputString + postfixString;

            

            outputString = finalOutputString;

            if (renameType == RenameType.Both || renameType == RenameType.AssetPathOnly)
            {
                outputAssetPath = prefixString + outputAssetPath;
                outputAssetPath = Path.GetFileNameWithoutExtension(outputAssetPath) + postfixString + Path.GetExtension(outputAssetPath);
                finalOutputAssetPath = inputAssetPath.Replace(tempAssetPath, outputAssetPath);
                outputAssetPath = finalOutputAssetPath;
            }

            if (renameType == RenameType.Both || renameType == RenameType.SceneNameOnly)
                renameLogs[i + 1] = "<br>[SCENE]&nbsp;" + inputString + " ------------> " + finalOutputString + "</br>";

            if (renameType == RenameType.Both || renameType == RenameType.AssetPathOnly)
                renameLogs[i + 1] = renameLogs[i + 1] + "<br>&nbsp;&nbsp;&nbsp;&nbsp;[ASSETPATH]&nbsp;" + inputAssetPath + " ------------> " + finalOutputAssetPath + "</br>";

            //FileUtil.

            if (applyActually)
            {
                Selection.gameObjects[i].name = finalOutputString;

                if (renameType == RenameType.Both || renameType == RenameType.AssetPathOnly)
                {

                    UnityEngine.Debug.Log(inputAssetPath);
                    UnityEngine.Debug.Log(Path.GetFileNameWithoutExtension(finalOutputAssetPath));

                    string renameResult = AssetDatabase.RenameAsset(inputAssetPath, Path.GetFileNameWithoutExtension(finalOutputAssetPath));
                    //UnityEngine.Debug.Log(renameResult);
                    //AssetDatabase.SaveAssets();
                    //AssetDatabase.Refresh();
                }
            }

            
            
            //AssetDatabase.GetAssetPath

        }

        renameLogs[Selection.gameObjects.Length + 1] = "<br>Total renamed GameObjects : " + Selection.gameObjects.Length .ToString() + "</br>";

        File.WriteAllLines(tempHtmPath, renameLogs);

        // Open htm by using chrome

        if (Selection.gameObjects.Length < 2 || applyActually == true)
            return;

        Process proc = new Process();

        try
        {
            proc.StartInfo.FileName = "chrome.exe";
            proc.StartInfo.Arguments = tempHtmPath;

            proc.Start();

            
        }
        catch
        {
            proc.Close();
            return;
        }
        

        proc.Close();
    }

    private void OnGUI()
    {

        GUILayout.Label(string.Empty, EditorStyles.boldLabel);

        GUILayout.Label(("This tool is for renaming selcted objects."), EditorStyles.boldLabel);
        GUILayout.Label(("Select \"GameObject\" and then set the fields for renaming."), EditorStyles.boldLabel);

        GUILayout.Label(string.Empty, EditorStyles.boldLabel);

        

        sourceString = EditorGUILayout.TextField("Original text : ", sourceString);
        targetString = EditorGUILayout.TextField("Replaced text : ", targetString);

        GUILayout.Label(string.Empty, EditorStyles.boldLabel);


        prefixString = EditorGUILayout.TextField("Add prefix : ", prefixString);
        postfixString = EditorGUILayout.TextField("Add postfix : ", postfixString);

        GUILayout.Label(string.Empty, EditorStyles.boldLabel);
        GUILayout.Label("Output Preview", EditorStyles.boldLabel);


        GUILayout.Label("Input Text : " + inputString, EditorStyles.boldLabel);
        GUILayout.Label("Output Text : " + outputString, EditorStyles.boldLabel);

        
        if (GUILayout.Button("Preview"))
        {
            renameObjects(false, RenameType.Both);
        }

        GUILayout.Label(string.Empty, EditorStyles.boldLabel);

        if (GUILayout.Button("Do Rename - Scene names only"))
        {
            renameObjects(true, RenameType.SceneNameOnly);
        }

        if (GUILayout.Button("Do Rename - Object AssetPath only"))
        {
            renameObjects(true, RenameType.AssetPathOnly);
        }

        this.Repaint();
        
        //EditorGUILayout.PropertyField(msg, GUILayout.Height(80));
    }
}
