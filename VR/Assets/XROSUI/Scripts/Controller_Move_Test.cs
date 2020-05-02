using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Move_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempVector3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            //print(this.transform.forward);
            tempVector3 = 3*transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tempVector3 = 3*-transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tempVector3 = transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tempVector3 = -transform.right * Time.deltaTime;
        }
        //TODO Add Rotation
        //TODO Add Up & Down
        //TODO Add Speed Adjustment

        transform.position += tempVector3;
    }
}
