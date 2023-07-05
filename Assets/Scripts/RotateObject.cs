using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Transform objectToRotate; // the object to be rotated
    private Vector3 directionVector; // the direction vector to rotate towards
    public RayOrientation rayOrientation;
    public DisappearAppear disappearAppear;

    private float rotationSpeed = 30.0f; // rotation speed in degrees per second
    private float currentRotationSpeed; // the current rotation speed

    private bool wasDirectionZero;

    void Start()
    {
        wasDirectionZero = false;
        currentRotationSpeed = rotationSpeed;
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

                // If the angle is larger than 90 degrees, increase rotation speed
                if (Mathf.Abs(angle) > 90.0f)
                {
                    currentRotationSpeed = rotationSpeed * 10;
                    StartCoroutine(ResetRotationSpeed());
                }

                // Rotate the object towards the projected direction vector
                objectToRotate.rotation = Quaternion.RotateTowards(objectToRotate.rotation, Quaternion.LookRotation(projectedVector), Time.deltaTime * currentRotationSpeed);

                //Debug.DrawRay(transform.position, projectedVector * 10, Color.green);
            }
        }
    }

    IEnumerator ResetRotationSpeed()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.5f);

        // Reset the rotation speed back to normal
        currentRotationSpeed = rotationSpeed;
    }
}
