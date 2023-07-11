using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;
using TMPro;


public class InterruptionLabeler : MonoBehaviour
{


    private float nextActionTime = 0.0f;
    public float period = 1f;
    public TMP_Text text;
    public string label;

    // Update is called once per frame
    void Update()
    {
        text.text = label;
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // A correct website page.
            StartCoroutine(GetRequest("https://64ac268e9edb4181202f2efa.mockapi.io/sounds"));
        }
    }

    IEnumerator GetRequest(string uri)
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
                    int freq = str.Count(f => (f == '{'));
                    if (freq < 26)
                    {
                        label = "Last Interruption: None";
                    } else if (freq < 51)
                    {
                        label = "Last Interruption: Door Open / Closed";
                    } else if (freq < 76)
                    {
                        label = "Last Interruption: Voice";
                    } else
                    {
                        label = "Last Interruption: Something dropped";
                    }
                    break;
            }
        }
    }
}
