using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonCounter : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    public float period = 1f;

    public RestService restService;

    private Content content;
    public Vector3 direction;

    public int personCount;

    public TMP_Text text;


    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            restService.GetJson();

            string j = restService.latestCameraJson;
            if (j != "")
            {
                content = JsonUtility.FromJson<Content>(j);

                int count = 0;
                foreach (string s in content.content)
                {
                    if (s == "person")
                    {
                        count++;
                    }
                }
                personCount = count;
                text.text = "persons: " + count.ToString();
            }
        }


    }
}
