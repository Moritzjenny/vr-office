using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class KeyBoardWindow : MonoBehaviour
{
    public GameObject dragableKeyboardWindowCorner;
    public Transform cube1;
    public Transform cube2;
    public Transform plane;
    private Vector3 initialPosition;
    private float initialDistance;
    private Vector3 initialScale;

    void Start()
    {
        initialPosition = plane.position;
        initialDistance = Vector3.Distance(cube1.position, cube2.position);
        initialScale = plane.localScale;
    }

    void Update()
    {
        float distance = Vector3.Distance(cube1.position, cube2.position);
        Vector3 direction = (cube2.position - cube1.position).normalized;

        // Calculate the position and rotation of the plane
        plane.position = cube1.position + direction * (distance / 2f);
        plane.rotation = Quaternion.LookRotation(direction);

        // Set the scale of the plane based on the initial scale and the current distance
        float scale = distance / initialDistance;
        plane.localScale = initialScale * scale;

        // Set the positions of the plane's corners so that they touch the cubes
        Vector3 corner1 = plane.TransformPoint(new Vector3(-0.5f, 0.5f, 0));
        corner1 = cube1.position;
        Vector3 corner2 = plane.TransformPoint(new Vector3(0.5f, -0.5f, 0));
        corner2 = cube2.position;
    }

    public void DisablePokeInteractionOnPivot()
    {
        //gameObject.GetComponent<PokeInteractable>().enabled = false;
        dragableKeyboardWindowCorner.SetActive(!dragableKeyboardWindowCorner.activeSelf);
    }

    public void ActivateKeyBoardWindowDragMode()
    {

    }
}
