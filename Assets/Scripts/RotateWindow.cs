using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWindow : MonoBehaviour
{
    int previousValue;

    public void RotateToCardinalDirection(int directionNumber, float duration)
    {
        if (directionNumber != previousValue) {
            previousValue = directionNumber;
            Quaternion targetRotation;
            switch (directionNumber)
            {
                case 1: // North
                    targetRotation = Quaternion.Euler(0f, 0f, 0f);
                    break;
                case 2: // East
                    targetRotation = Quaternion.Euler(0f, 90f, 0f);
                    break;
                case 3: // South
                    targetRotation = Quaternion.Euler(0f, 180f, 0f);
                    break;
                case 4: // West
                    targetRotation = Quaternion.Euler(0f, 270f, 0f);
                    break;
                default:
                    Debug.LogError("Invalid direction number: " + directionNumber);
                    return;
            }

            StartCoroutine(RotateOverTime(targetRotation, duration));
        }
    }

    IEnumerator RotateOverTime(Quaternion targetRotation, float duration)
    {
        Quaternion startRotation = transform.rotation;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float timeRatio = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, timeRatio);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
