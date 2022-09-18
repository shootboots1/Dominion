using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;

    public Camera cam;

    public float zoom;
    public float maxZoom, minZoom;

    public float zoomForce = 1.5f;

    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate()
    {
        zoom = Input.GetAxisRaw("Mouse ScrollWheel");
        if (cam.orthographicSize >= maxZoom && cam.orthographicSize <= minZoom)
        {
            cam.orthographicSize -= zoom * zoomForce;
        }
        if (cam.orthographicSize < maxZoom)
        {
            cam.orthographicSize = maxZoom + 0.1f;
        }
        if(cam.orthographicSize > minZoom)
        {
            cam.orthographicSize = minZoom - 0.1f;
        }
        if (Input.GetMouseButton(1))
        {
            Diference = (cam.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            cam.transform.position = Origin - Diference;
        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(2))
        {
            cam.transform.position = ResetCamera;
        }
    }
}
