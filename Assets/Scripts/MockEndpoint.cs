using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MockEndpoint : MonoBehaviour
{
    private static MockEndpoint _instance;

    public SoundList soundList = new SoundList();
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

    void Start()
    {
        json = JsonUtility.ToJson(soundList);
    }

    // Add other class methods here...

    public string GetData()
    {
        return json;
    }
}
