using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MockEndpoint : MonoBehaviour
{
    private static MockEndpoint _instance;

    public SoundList soundList;
    public Content content;
    private string json;


    public static MockEndpoint Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MockEndpoint not instantiated.");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Add other class methods here...

    public string GetData()
    {
        json = JsonUtility.ToJson(soundList);
        return json;
    }


    public string GetCameraData()
    {
        json = JsonUtility.ToJson(content);
        return json;
    }
}
