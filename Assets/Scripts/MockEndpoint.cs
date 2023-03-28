using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MockEndpoint : MonoBehaviour
{
    private static MockEndpoint _instance;

    public SoundList soundList;
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
}
