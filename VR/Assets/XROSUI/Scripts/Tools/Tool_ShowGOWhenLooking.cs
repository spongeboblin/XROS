using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_ShowGOWhenLooking : MonoBehaviour
{
    public Camera myCamera;
    public GameObject GOToShow;
    public float degreeToShow = 30f;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCameraSeesMe();
    }

    void CheckIfCameraSeesMe()
    {
        float currentDegree = Vector3.Angle(myCamera.transform.forward, this.transform.forward);
        //Dev.Log(currentDegree);
        if(currentDegree < degreeToShow)
        {
            GOToShow.SetActive(true);
        }
        else
        {
            GOToShow.SetActive(false);
        }
    }
}
