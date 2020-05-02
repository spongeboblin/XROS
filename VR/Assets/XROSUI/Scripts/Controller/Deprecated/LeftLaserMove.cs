using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLaserMove : MonoBehaviour
{
    private Vector3 priorDirection;
    void onGrab(){
        GameObject LeftLaserEmitter=GameObject.Find("LeftLaserEmitter");
        GameObject LeftBaseController=GameObject.Find("LeftBaseController");
        priorDirection=LeftLaserEmitter.transform.forward;
        LeftLaserEmitter.transform.forward=LeftBaseController.transform.forward;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject laser=GameObject.Find("LeftLaserEmitter");
        GameObject target= GameObject.Find("LaserTrack");

        if(Input.GetKey(KeyCode.A)){
            transform.RotateAround(laser.transform.position,Vector3.up,-10f*Time.deltaTime);
        }
         if(Input.GetKey(KeyCode.D)){
            transform.RotateAround(laser.transform.position,Vector3.up,10f*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W)){//Moving forwards
            transform.Rotate(new Vector3(-10f*Time.deltaTime,0,0));
            // transform.RotateAround(laser.transform.position,laser.transform.right,-10f*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(new Vector3(10f*Time.deltaTime,0,0));
            // transform.RotateAround(laser.transform.position,laser.transform.right,10f*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)){
            // print("Q pressed");
            laser.transform.forward=(target.transform.position-laser.transform.position).normalized;
            // Vector3 direction = (target.transform.position - laser.transform.position).normalized;
            // Vector3 NormalVector=Vector3.Cross(laser.transform.forward,direction);
            // Quaternion quaternion=Quaternion.FromToRotation(laser.transform.forward,direction);
            // transform.RotateAround(laser.transform.position,NormalVector,Vector3.Angle(laser.transform.forward,direction));
        }
    }
}
