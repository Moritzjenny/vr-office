using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject objectToToggle;
    public bool isOff;

    void Start()
    {
        objectToToggle.SetActive(!isOff);
    }

    public void TriggerToggleObject()
    {
        objectToToggle.SetActive(isOff);
        isOff = !isOff;  
    }
}
