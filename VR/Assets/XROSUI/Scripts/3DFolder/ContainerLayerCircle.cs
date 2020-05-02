using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerLayerCircle : MonoBehaviour
{
    int maxSocket;
    // int maxObject;
    private float containerObjectRadius = 0.05f;
    private int Rmax;
    private int Cmax;
    private float Rlast = 0;
    private float Clast = 0;
    private float RlastforSocket = 0;
    private float ClastforSocket = 0;
    private float buffery = 0.2f;
    private float bufferz = 0.2f;
    public float layervalue = 0f;
    public List<ContainerObject> containerobjectlist = new List<ContainerObject>();
    public List<ContainerSocket> containersocketlist = new List<ContainerSocket>();
    float r = 0.25f;
    public void AddObject(GameObject go)
    {
        go.name = "CO " + containerobjectlist.Count;
        ContainerObject co = go.GetComponent<ContainerObject>();
        containerobjectlist.Add(co);

        //int currentIndex = containerobjectlist.Count;
        //containersocketlist[currentIndex].
        TraditionalAddObject(co);
    }
    void TraditionalAddObject(ContainerObject co)
    {
        // co.transform.position = this.transform.position + Vector3.up * 0.5f * containerobjectlist.Count;
        ////Place object
        float Ri;
        float Ci;
        ////print("set position:");
        if (containerobjectlist.Count == 1)
        {
            Ci = 0;
            Ri = 0;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        //2
        if (containerobjectlist.Count == 2)
        {
            Ci = 0;
            Ri = r;
            Clast = Ci;
            Rlast = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        //3
        if (containerobjectlist.Count == 3)
        {
            Ci = (float)(-r / 1.414);
            Ri = (float)(r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 4)
        {
            Ci = -r;
            Ri = 0;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 5)
        {
            Ci = (float)(-r / 1.414);
            Ri = (float)(-r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 6)
        {
            Ci = 0;
            Ri = -r;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 7)
        {
            Ci = (float)(r / 1.414);
            Ri = (float)(-r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 8)
        {
            Ci = r;
            Ri = 0;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
        if (containerobjectlist.Count == 9)
        {
            Ci = (float)(r / 1.414);
            Ri = (float)(r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
        }
    }
    public void AddObjectSocket(GameObject go)
    {
        ContainerSocket cs = go.GetComponent<ContainerSocket>();
        cs.name = "CS " + containersocketlist.Count;
        containersocketlist.Add(cs);
        //co.transform.position = this.transform.position + Vector3.up * 0.5f * containerobjectlist.Count;
        //Place object
        //1
        float Ri;
        float Ci;
        ////print("set position:");
        //Ri = RlastforSocket;
        //print("Ri: " + Ri);
        //Ci = ClastforSocket;
        // print("Ci: " + Ci); 
        //1
        if (containersocketlist.Count == 1)
        {
            Ci = 0;
            Ri = 0;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        //2
        if (containersocketlist.Count == 2)
        {
            Ci = 0;
            Ri = r;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        //3
        if (containersocketlist.Count == 3)
        {
            Ci = (float)(-r / 1.414);
            Ri = (float)(r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 4)
        {
            Ci = -r;
            Ri = 0;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 5)
        {
            Ci = (float)(-r / 1.414);
            Ri = (float)(-r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 6)
        {
            Ci = 0;
            Ri = -r;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 7)
        {
            Ci = (float)(r / 1.414);
            Ri = (float)(-r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 8)
        {
            Ci = r;
            Ri = 0;
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
        if (containersocketlist.Count == 9)
        {
            Ci = (float)(r / 1.414);
            Ri = (float)(r / 1.414);
            ClastforSocket = Ci;
            RlastforSocket = Ri;
            float x = this.transform.position.x + (Ci);
            float y = this.transform.position.y + (Ri);
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
        }
    }
    public int GetMaxSocket()
    {
        float a = this.transform.localScale.x;
        float b = this.transform.localScale.y;
        float c = this.transform.localScale.z;
        Cmax = (int)(c / (buffery + (containerObjectRadius * 2)));
        // print("Cmax is "+ Cmax);
        Rmax = (int)(b / (bufferz + (containerObjectRadius * 2)));
        maxSocket = Cmax * Rmax;
        return maxSocket;
    }
    //public int GetMaxObject()
    //{
    //    float a = this.transform.localScale.x;
    //    float b = this.transform.localScale.y;
    //    float c = this.transform.localScale.z;
    //    Cmax = (int)(c / (buffery + (containerObjectRadius * 2)));
    //    // print("Cmax is "+ Cmax);
    //    Rmax = (int)(b / (bufferz + (containerObjectRadius * 2)));
    //    maxObject = Cmax * Rmax;
    //    return maxObject;
    //}

    public bool IsFull()
    {
        maxSocket = Cmax * Rmax;
        //maxObject = Cmax * Rmax;
        //  print("Is Full: " + (containerobjectlist.Count >= max));
        return containerobjectlist.Count >= maxSocket;
    }
    // Start is called before the first frame update
    void Awake()
    {
        //x = this.GetComponent<Collider>().bounds.size.x;// PF_layerObject.collider.bounds.size.x;
        //z = this.GetComponent<Collider>().bounds.size.z; //PF_layerObject.collider.bounds.size.z;
        //y = this.GetComponent<Collider>().bounds.size.y;// PF_layerObject.collider.bounds.size.y;
        float a = this.transform.localScale.x;
        //  print("a=" + a);
        float b = this.transform.localScale.y;
        // print("b=" + b);// depth
        float c = this.transform.localScale.z;
        // print("c=" + c);
        float Radius = a / 4;
        // print("R=" + Radius);
        Cmax = (int)(c / (buffery + (containerObjectRadius * 2)));
        // print("Cmax is "+ Cmax);
        Rmax = (int)(a / (bufferz + (containerObjectRadius * 2)));
        // print("Rmax is "+ Rmax);
        //print(containerObjectRadius);
        //IsFull();
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void HideContainerObject()
    {
        for (int i = 0; i < containerobjectlist.Count; i++)
        {
            containerobjectlist[i].gameObject.SetActive(false);
        }
    }

    public void ShowContainerObject()
    {
        for (int i = 0; i < containerobjectlist.Count; i++)
        {
            containerobjectlist[i].gameObject.SetActive(true);
        }
    }
}
