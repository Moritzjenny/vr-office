using UnityEngine;
using Oculus.Interaction;

public class CollisionDetection : MonoBehaviour
{

    private Vector3 originalPosition;
    public ChangeEnvironment changeEnvironment;
    public int index = 0;

    void Start()
    {
        // Store the object's original position
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with a game object tagged as "Table"
        if (other.gameObject.CompareTag("Table"))
        {
            // Disable the Grabbable component temporarily
            Grabbable grabbable = GetComponent<Grabbable>();
            grabbable.enabled = false;

            // Teleport the object back to its original position
            transform.position = originalPosition;

            // Re-enable the Grabbable component
            grabbable.enabled = true;

            // Call the TriggerNewEnvironment() function
            TriggerNewEnvironment();
        }
    }

    void TriggerNewEnvironment()
    {
       if (index == 0)
        {
            changeEnvironment.SetEnvironment1();
        }
        if (index == 1)
        {
            changeEnvironment.SetEnvironment2();
        }
        if (index == 2)
        {
            changeEnvironment.SetEnvironment3();
        }
    }

    public void ResetOriginalPosition()
    {
        originalPosition = transform.position;
    }
}
