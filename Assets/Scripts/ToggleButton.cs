using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{

    public GameObject toggleButton1;
    public GameObject toggleButton2;
    public bool defaultToggle;
    private bool isToggled;

    // Start is called before the first frame update
    void Start()
    {
        toggleButton2.SetActive(false);
        toggleButton1.SetActive(true);
        if (defaultToggle)
        {
            ToggleToggleButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleToggleButton()
    {
        isToggled = !isToggled;
        toggleButton2.SetActive(isToggled);
        toggleButton1.SetActive(!isToggled);

    }
}
