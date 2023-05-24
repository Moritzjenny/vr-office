using UnityEngine;

public class ChangeEnvironment : MonoBehaviour
{
    public GameObject environment1;
    public GameObject environment2;
    public GameObject environment3;

    public void SetEnvironment1()
    {
        environment1.SetActive(true);
        environment2.SetActive(false);
        environment3.SetActive(false);
    }

    public void SetEnvironment2()
    {
        environment1.SetActive(false);
        environment2.SetActive(true);
        environment3.SetActive(false);
    }

    public void SetEnvironment3()
    {
        environment1.SetActive(false);
        environment2.SetActive(false);
        environment3.SetActive(true);
    }
}
