using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CalibrateSkeletonForMergedScene : MonoBehaviour
{
    public float Scale = 1.0f;
    float a = 1.0f;     // a = (HMD - left_controller) / scale
    float b = 1.2f;     // b = (HMD - left_controller) / single-arm-length
    float c = 0.5f;     // c = distance to HMD
    float k = 25.0f;    // a fixed multiplier applied to distance
    float offset_x = 0.0f;     // This is for TEST UI ONLY
    float offset_y = 0.0f;     // This is for TEST UI ONLY
    float offset_z = -0.1f;     // This is for TEST UI ONLY
    // UI to test position update ONLY (in the future, all UIs should call to update position)
    GameObject thisUIPanel;
    // UI components
    public Button CalibrateButton;
    public Text WorldScaleText;
    // Generic (from systems)
    GameObject LeftController;
    GameObject RightController;
    GameObject HMD;
    Vector3 LeftControllerPos;
    Vector3 RightControllerPos;
    Vector3 HMDPos;
    float LHDistanceGeneric = 1.0f;
    // Skeleton
    public Vector3[] skeletonPos = new Vector3[17];
    Vector3 LeftHandPos;
    Vector3 HeadPos;
    float LHDistanceSkeleton = 1.0f;
    // Skeleton Global Variables
    [SerializeField] string default_skeleton_path;
    //[SerializeField] Animator animator;
    //[SerializeField] GameObject BoneRoot;
    Vector3[] Joints = new Vector3[17];
    Vector3[] DefaultBoneNormalized = new Vector3[12];
    public static Vector3[] BoneNormalized = new Vector3[12];
    Vector3[] LerpedNormalizeBone = new Vector3[12];
    Quaternion[] DefaultBoneRot = new Quaternion[17];
    Quaternion[] DefaultBoneLocalRot = new Quaternion[17];
    Vector3[] DefaultXAxis = new Vector3[17];
    Vector3[] DefaultYAxis = new Vector3[17];
    Vector3[] DefaultZAxis = new Vector3[17];
    public List<Transform> BoneList = new List<Transform>();
    int[,] BoneJointIdx = new int[,]
    { { 0, 2 }, { 2, 3 }, { 0, 5 }, { 5, 6 }, { 0, 7 }, { 7, 8 }, { 8, 9 }, { 9, 10 }, { 9, 12 }, { 12, 13 }, { 9, 15 }, { 15, 16 }
    };

    void Start()
    {
        // UI initialization
        Button calibrateBtn = CalibrateButton.GetComponent<Button>();
        calibrateBtn.onClick.AddListener(Calibrate);
        WorldScaleText = GameObject.Find("WorldScaleText").GetComponent<Text>();

        // For test ONLY
        thisUIPanel = GameObject.Find("ScaleDisplay");

        // Function initialization
        LeftController = GameObject.Find("LeftController");
        RightController = GameObject.Find("RightController");
        HMD = GameObject.Find("HMD");

        // Step 1: Load and draw default skeleton
        // TODO
        // GetBones();
        // LoadSkeleton();

        Scale = ComputeScale();
        Debug.Log($"Default world scale: {Scale}");
    }

    void Update()
    {
        UpdateGenericPos();
        // Print out instruction

        // Trigger option 1: Use keypoint Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scale = ComputeScale();
            Debug.Log($"World scale measured: {Scale}");
            // Update scale of UI -- MAY DEPRECATE TO HAVE EACH FUNCTION UPDATE BY ITSELF

        }
    }

    public void Calibrate()
    {
        Scale = ComputeScale();
        Dev.Log($"World scale measured: {Scale}");
        WorldScaleText.text = $"World scale measured: {Scale}";

        // Update UI position for test ONLY
        Vector3 facingDirection = normalize(new Vector3(0.0f, 2.8f, -15.3f));
        UpdateUIPos(thisUIPanel, facingDirection);
    }

    public void UpdateUIPos(GameObject UIObject, Vector3 facingDirection)
    {
        Vector3 result = ComputePosition(UIObject.transform.position.y, facingDirection);
        UIObject.transform.position = result;
        // UIObject.transform.position = new Vector3(0.0f, 1.0f, -15.3f);

        // Debug.Log("NEW 2");
        // Debug.Log(UIObject.transform.position);
    }

    Vector3 ComputePosition(float oldPosCenter_y, Vector3 facingDirection)
    {
        float distance = c / b * a * Scale * k;
        // oldDirection = new Vector3(oldPosCenter.x - HMDPos.x, oldPosCenter.y - HMDPos.y, oldPosCenter.z - HMDPos.z);
        // Vector3 facingDirection = normalize(oldDirection);
        return new Vector3(HMDPos.x + facingDirection.x * distance + offset_x, oldPosCenter_y + offset_y, HMDPos.z + facingDirection.z * distance + offset_z);
    }

    float ComputeScale()
    {
        // Compute generic distance between left controller and HMD
        LHDistanceGeneric = ComputeGeneric();
        // Compute skeleton distance between left controller and HMD
        LHDistanceSkeleton = 1.0f; // ComputeSkeleton();                // TO BE CALLED AFTER SKELETON IS IMPORTED
        // Compute scale of skeleton, S
        return LHDistanceGeneric / LHDistanceSkeleton;
    }

    float ComputeGeneric()
    {
        // Load location of headset and left controller (default for right-handers)
        UpdateGenericPos();
        // Compute generic distance between HMD and left controller
        return ComputeDistance(LeftControllerPos, HMDPos);
    }

    float ComputeSkeleton()
    {
        // Load skeleton position
        LeftHandPos = BoneNormalized[(int)JointsIdx.LeftHand];
        HeadPos = BoneNormalized[(int)JointsIdx.Head];
        // Compute skeleton distance between HMD and left controller
        return ComputeDistance(LeftHandPos, HeadPos);
    }

    float ComputeDistance(Vector3 pos1, Vector3 pos2)
    {
        
        float deltaX = pos1[0] - pos2[0];
        float deltaY = pos1[1] - pos2[1];
        float deltaZ = pos1[2] - pos2[2];
        return (float)Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    }

    void UpdateGenericPos()
    {
        LeftControllerPos = LeftController.transform.position;
        RightControllerPos = RightController.transform.position;
        HMDPos = HMD.transform.position;
    }

    Vector3 normalize(Vector3 vec)
    {
        float magnitude = vec.x * vec.x + vec.y * vec.y + vec.z * vec.z;
        return new Vector3(vec.x / magnitude, vec.y / magnitude, vec.z / magnitude);
    }

    /*
    void GetBones()
    {
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.Hips));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftFoot));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightLowerLeg));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightFoot));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.Spine));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.Chest));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.Neck));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.Head));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightUpperArm));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightLowerArm));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.RightHand));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftLowerArm));
        BoneList.Add(animator.GetBoneTransform(HumanBodyBones.LeftHand));

        for (int i = 0; i < 17; i++)
        {
            var rootT = animator.GetBoneTransform(HumanBodyBones.Hips).root;
            DefaultBoneRot[i] = BoneList[i].rotation;
            DefaultBoneLocalRot[i] = BoneList[i].localRotation;
            DefaultXAxis[i] = new Vector3(
                Vector3.Dot(BoneList[i].right, rootT.right),
                Vector3.Dot(BoneList[i].up, rootT.right),
                Vector3.Dot(BoneList[i].forward, rootT.right)
            );
            DefaultYAxis[i] = new Vector3(
                Vector3.Dot(BoneList[i].right, rootT.up),
                Vector3.Dot(BoneList[i].up, rootT.up),
                Vector3.Dot(BoneList[i].forward, rootT.up)
            );
            DefaultZAxis[i] = new Vector3(
                Vector3.Dot(BoneList[i].right, rootT.forward),
                Vector3.Dot(BoneList[i].up, rootT.forward),
                Vector3.Dot(BoneList[i].forward, rootT.forward)
            );
        }
        for (int i = 0; i < 12; i++)
        {
            DefaultBoneNormalized[i] = (BoneList[BoneJointIdx[i, 1]].position - BoneList[BoneJointIdx[i, 0]].position).normalized;
        }
    }

    void LoadSkeleton()
    {
        StreamReader fi = new StreamReader(Application.dataPath + default_skeleton_path);
        string all = fi.ReadToEnd();
        if (all != "0")
        {
            string[] axis = all.Split(']');
            float[] x = axis[0].Replace("[", "").Replace("\r\n", "").Replace("\n", "").Split(' ').Where(s => s != "").Select(f => float.Parse(f)).ToArray();
            float[] y = axis[2].Replace("[", "").Replace("\r\n", "").Replace("\n", "").Split(' ').Where(s => s != "").Select(f => float.Parse(f)).ToArray();
            float[] z = axis[1].Replace("[", "").Replace("\r\n", "").Replace("\n", "").Split(' ').Where(s => s != "").Select(f => float.Parse(f)).ToArray();
            for (int i = 0; i < 17; i++) Joints[i] = new Vector3(x[i], y[i], -z[i]);
            for (int i = 0; i < 12; i++) BoneNormalized[i] = (Joints[BoneJointIdx[i, 1]] - Joints[BoneJointIdx[i, 0]]).normalized;
        }
        else
        {
            Debug.Log("Warning: All joint 0");
        }
    }
    */
}

enum JointsIdx
{
    Hips,
    RightUpperLeg,
    RightLowerLeg,
    RightFoot,
    LeftUpperLeg,
    LeftLowerLeg,
    LeftFoot,
    Spine,
    Chest,
    Neck,
    Head,
    LeftUpperArm,
    LeftLowerArm,
    LeftHand,
    RightUpperArm,
    RightLowerArm,
    RightHand
}
