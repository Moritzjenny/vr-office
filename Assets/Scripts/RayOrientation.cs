using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOrientation : MonoBehaviour
{
    public float rayDistance = 10f;
    public Color rayColor = Color.red;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    public RestService restService;

    private SoundList soundList;
    public Vector3 direction;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            restService.GetJson();

            string j = restService.latestJson;
            if (j != "")
            {
                soundList = JsonUtility.FromJson<SoundList>(j);
                direction.x = soundList.sounds[0].direction.x;
                direction.z = soundList.sounds[0].direction.y;
                direction.y = soundList.sounds[0].direction.z;

                // Rotate the direction vector by 45 degrees around the y-axis
                direction = Quaternion.Euler(0f, 45f, 0f) * direction;

                // Skew the direction vector (this value is fine with the mic being placed about 1m in front of the user)
                if (direction.sqrMagnitude > 0.5)
                {
                    direction += new Vector3(0, 0, 0.65f);
                }
            }
        }

        Debug.DrawRay(transform.position, direction * rayDistance, rayColor);
    }
}
