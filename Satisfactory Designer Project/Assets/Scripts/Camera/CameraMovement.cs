using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public float dragSpeed = 2;

    [Header("Zooming")]
    public float zoomSpeed = 2f;
    public float minFov = 15f;
    public float maxFov = 90f;

    private Vector3 dragOrigin;

    void Update()
    {   
        //Dragging
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        Vector3 difference = Input.mousePosition - dragOrigin;

        Vector3 move = new Vector3(-difference.x * dragSpeed * Time.deltaTime, 0, -difference.y * dragSpeed * Time.deltaTime);
        transform.Translate(move, Space.World);

        dragOrigin = Input.mousePosition;

        //Zooming
        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }
}
