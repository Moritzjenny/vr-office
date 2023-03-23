using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;
using System;


public class RestService : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    public float period = 1f;

    public string url;
    public MockEndpoint mockEndpoint;
    public bool mock;

    private string latestJson = "";
    private string latestJsonOld = "";


    void Update()
    {
        if (latestJson != latestJsonOld)
        {
            latestJsonOld = latestJson;
        }
    }

    public string GetJson()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://63e11f4b59bb472a7431470f.mockapi.io/position", result =>
        {
            latestJson = result;
        }));
        return latestJson;
    }


    IEnumerator GetRequest(string uri, Action<string> callback)
    {
        if (!mock)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                // This code is very embarrassing, however its also just to play around
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        string str = webRequest.downloadHandler.text;
                        break;
                }
                callback("str");
            }
        }
        else
        {
            callback(mockEndpoint.GetData());
        }

    }
}