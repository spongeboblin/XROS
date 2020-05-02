using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigGeneralFunction : MonoBehaviour
{
    public GameObject Parent;
    public bool relative;
    public bool PositionRetain;
    public float RelativePosition_x;
    public float RelativePosition_y;
    public float RelativePosition_z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PositionRetain)
        {
            this.PositionReset();
        }
    }

    //this method is used to reposition itself*/
    public void PositionReset()
    {
        if (!relative)
        {
            this.transform.position =
            Parent.transform.position +
            new Vector3(RelativePosition_x, RelativePosition_y, RelativePosition_z);
        }
        else
        {
            this.transform.position = Parent.transform.position +
            Parent.transform.forward * RelativePosition_z +
            Parent.transform.up * RelativePosition_y +
            Parent.transform.right * RelativePosition_x;
        }
    }
    public void DirectionReset()
    {
        this.transform.forward = Parent.transform.forward;
    }
}
