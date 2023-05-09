using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform objectToRotate; // the object to be rotated
    private Vector3 directionVector; // the direction vector to rotate towards
    public RayOrientation rayOrientation;
    public DisappearAppear disappearAppear;

    public float rotationSpeed = 1.0f; // rotation speed in degrees per second

    private bool wasDirectionZero;

    void Start()
    {
        wasDirectionZero = false;
    }

    void Update()
    {
        directionVector = rayOrientation.direction;
        if (directionVector == new Vector3(0, 0, 0))
        {
            disappearAppear.Disappear();
            wasDirectionZero = true;
        }
        else
        {
            disappearAppear.Appear();

            // Project direction vector onto horizontal plane
            Vector3 projectedVector = new Vector3(-directionVector.x, 0f, -directionVector.z);
            projectedVector.Normalize(); // normalize the vector to get a unit vector

            if (wasDirectionZero)
            {
                objectToRotate.rotation = Quaternion.LookRotation(projectedVector);
                wasDirectionZero = false;
            }
            else
            {
                // Calculate angle between projected direction vector and object's current forward direction
                float angle = Vector3.SignedAngle(objectToRotate.forward, projectedVector, Vector3.up);

                // Rotate the object towards the projected direction vector
                objectToRotate.rotation = Quaternion.RotateTowards(objectToRotate.rotation, Quaternion.LookRotation(projectedVector), Time.deltaTime * rotationSpeed);

                //Debug.DrawRay(transform.position, projectedVector * 10, Color.green);
            }
        }
    }
}
