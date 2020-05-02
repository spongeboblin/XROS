using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ContainerManagerCircle : MonoBehaviour
{
    public List<ContainerObject> containerobjectlist = new List<ContainerObject>();
    public List<ContainerSocket> containersocketlist = new List<ContainerSocket>();
    public List<ContainerLayerCircle> containerlayercirclelist = new List<ContainerLayerCircle>();
    public GameObject PF_Socket;
    public GameObject PF_containerObject;
    public GameObject PF_layerCircleObject;
    public GameObject StartPoint;
    public GameObject controllerhand_Left;
    public GameObject controllerhand_Right;
    public float lefthandvalue;
    public float righthandvalue;
    //GameObject Container_Cube;
    private float depthValue = 0.1f;
    //Debug only
    GameObject CO;
    GameObject CS;
    //
    //
    public Transform planeTarget;
    public Transform target;
    void Start()
    {
        controllerhand_Right = GameObject.Find("RightDirectController");
        controllerhand_Left = GameObject.Find("LeftDirectController");
        //TODO for loop to generate layers
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(PF_layerCircleObject, this.transform.position + Vector3.back * 0.15f * i, Quaternion.identity);
            go.name = "Layer " + i;
            depthValue += 0.2f;
            //print("The " + i + " layer value is " + value);
            go.transform.SetParent(this.transform);
            ContainerLayerCircle co = go.GetComponent<ContainerLayerCircle>();
            co.layervalue = depthValue;
            containerlayercirclelist.Add(co);
        }
        AddAllContainerSocket();
        for (int i = 0; i < 5; i++)
        {
            //print(true);
            AddContainerObject();
        }
        for (int i = 0; i < 4; i++)
        {
            //print(true);
            AddContainerObject();
            Color c = Color.red;
            c.a = 0.3f;
            CO.GetComponent<MeshRenderer>().material.SetColor("_Color", c);
            //CO.GetComponent<MeshRenderer>().material.color.a = 0.3f;

        }
        for (int i = 0; i < 6; i++)
        {
            //print(true);
            AddContainerObject();
            Color c = Color.blue;
            c.a = 0.3f;
            CO.GetComponent<MeshRenderer>().material.SetColor("_Color", c);

        }
        for (int i = 0; i < 6; i++)
        {
            //print(true);
            AddContainerObject();
            Color c = Color.green;
            c.a = 0.3f;
            CO.GetComponent<MeshRenderer>().material.SetColor("_Color", c);

        }
        for (int i = 0; i < 6; i++)
        {
            //print(true);
            AddContainerObject();
            Color c = Color.yellow;
            c.a = 0.3f;
            CO.GetComponent<MeshRenderer>().material.SetColor("_Color", c);

        }


    }
    // Update is called once per frame
    void Update()
    {
        CheckDistanceForEach();
    }
    public void AddContainerObject()
    {
        //print("hi");
        for (int i = 0; i < containerlayercirclelist.Count; i++)
        {
            //print("hi2");
            if (!containerlayercirclelist[i].IsFull())
            {
                //print("hi3");
                CO = Instantiate(PF_containerObject, transform.position + transform.forward * 2, Quaternion.identity);
                //CO.name = "CO";
                containerlayercirclelist[i].AddObject(CO);
                return;
            }
        }
    }
    public void AddAllContainerSocket()
    {
        //print("xhi");
        for (int i = 0; i < containerlayercirclelist.Count; i++)
        {
            //print("xhi2" + containerlayerlist[i].GetMax());
            //if (!containerlayerlist[i].IsFull())
            for (int j = 0; j < containerlayercirclelist[i].GetMaxSocket(); j++)
            {
                //print("Max Socket " + containerlayerlist[i].GetMax());
                CS = Instantiate(PF_Socket, transform.position + transform.forward * 2, Quaternion.identity);
                containerlayercirclelist[i].AddObjectSocket(CS);
            }
        }
    }
    #region  CheckDistanceForEach
    public void CheckDistanceForEach()
    {
        lefthandvalue = Vector3.Distance(controllerhand_Left.transform.position, StartPoint.transform.position);
        righthandvalue = Vector3.Distance(controllerhand_Right.transform.position, StartPoint.transform.position);
        //Dev.Log("righthandvalue"+ righthandvalue);
        float totalvalueleft;
        float totalvalueright;
        totalvalueleft = lefthandvalue - 0.1f;
        //Dev.Log("total value" + totalvalue);
        totalvalueright = righthandvalue - 0.1f;
        //Dev.Log("total value" + totalvalue);
        for (int i = 0; i < containerlayercirclelist.Count; i++)
        {
            if (totalvalueleft <= containerlayercirclelist[i].layervalue)
            {
                containerlayercirclelist[i].HideContainerObject();
                containerlayercirclelist[i].gameObject.SetActive(false);
            }
            else if (totalvalueright <= containerlayercirclelist[i].layervalue)
            {
                containerlayercirclelist[i].HideContainerObject();
                containerlayercirclelist[i].gameObject.SetActive(false);
            }
            else if (totalvalueleft > containerlayercirclelist[i].layervalue)
            {
                containerlayercirclelist[i].ShowContainerObject();
                containerlayercirclelist[i].gameObject.SetActive(true);
            }
            else if (totalvalueright > containerlayercirclelist[i].layervalue)
            {
                containerlayercirclelist[i].ShowContainerObject();
                containerlayercirclelist[i].gameObject.SetActive(true);
            }
        }
        //slidervalue from 0 to 0.8
        //layervalue 0.2 0.4 0.6
    }

    //public float GetDistanceToPoint()
    //{
    //    Plane plane= new Plane(planeTarget.up, planeTarget.position);
    //    float distance = plane.GetDistanceToPoint(target.position);
    //    print("distance:" + distance);
    //    //return distance;
    //}
    #endregion
    #region check distance between the controller and layer, if<1 disappear 
    //public void CheckDistance()
    //{
    //    GameObject controllerhand = GameObject.Find("righthand");
    //    float ContainerDepth;
    //    Container_Cube = GameObject.Find("Container_Cube");
    //    ContainerDepth = Container_Cube.GetComponent<Collider>().bounds.size.x;
    //    print("ContainerDepth is" + ContainerDepth);
    //    float dis2;
    //    //dis2 = Vector3.Distance(controllerhand.transform.position, );

    //    //for (float i=0;i<ContainerDepth;i++) 
    //    //{ 
    //    //}
    //    GameObject disappearlayer = GameObject.Find("Container_Cube");
    //    float dis;
    //    dis = Vector3.Distance(controllerhand.transform.position, disappearlayer.transform.position);
    //    // print("dis=" + dis);
    //    if (dis <= 0.2f)
    //    {
    //        containerlayerlist[0].gameObject.SetActive(false);
    //    }
    //    else if (dis > 1.0)
    //    {
    //        containerlayerlist[0].gameObject.SetActive(true);
    //    }
    //}
    #endregion
    #region check value
    public void CheckValue()
    {
        GameObject controllerhand = GameObject.Find("righthand");
        GameObject endpoint = GameObject.Find("EndPoint");
        float dis;
        dis = Vector3.Distance(controllerhand.transform.position, endpoint.transform.position);
        print("dis is" + dis);
        if (dis >= 0.4f && dis <= 0.45f)
        {
            containerlayercirclelist[0].gameObject.SetActive(false);
        }
        else if (dis > 0.5)
        {
            containerlayercirclelist[0].gameObject.SetActive(true);
        }
        if (dis >= 0.2f && dis <= 0.25f)
        {
            containerlayercirclelist[1].gameObject.SetActive(false);
        }
        else if (dis > 0.3)
        {
            containerlayercirclelist[1].gameObject.SetActive(true);
        }
        if (dis >= 0 && dis <= 0.12)
        {
            containerlayercirclelist[2].gameObject.SetActive(false);
        }
        else if (dis > 0.1)
        {
            containerlayercirclelist[2].gameObject.SetActive(true);
        }
    }
    #endregion
    #region check angel between the cube and controller
    //public void CheckAngle() 
    //{ 
    //    GameObject controllerhand = GameObject.Find("righthand");
    //    //print("Containerforward" + this.transform.forward);
    //    print("test: " +Vector3.Dot(this.transform.forward, controllerhand.transform.forward));
    //}
    #endregion
}