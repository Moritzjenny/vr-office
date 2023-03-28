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
                direction.y = soundList.sounds[0].direction.y;
                direction.z = soundList.sounds[0].direction.z;
            }
        }


        Debug.DrawRay(transform.position, direction * rayDistance, rayColor);
    }
}
