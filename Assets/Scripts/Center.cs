using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{

    public Transform eyeTransform;
    public Transform structureTransform;
    private Vector3 initPos;
    private Vector3 eyePos;
    private Quaternion eyeRot;
    private Quaternion initRot;

    // Start is called before the first frame update
    void Start()
    {
        initPos = structureTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CenterScene()
    {
        eyePos = eyeTransform.position;
        eyeRot = eyeTransform.rotation;
        structureTransform.position = initPos + eyePos;
        structureTransform.rotation = new Quaternion(0, eyeTransform.rotation.y, 0, eyeTransform.rotation.w);
    }
}
