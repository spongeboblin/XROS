using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneById(int id)
    {
        Core.Ins.SceneManager.LoadSceneById(id);
    }
}
