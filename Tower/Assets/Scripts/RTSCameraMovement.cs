using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraMovement : MonoBehaviour
{
    public float ScrollSpeed = 15.0f;
    public float ScrollEdge = 0.0f;

    private float HorizontalScroll = 1.0f;
    private float VerticalScroll = 1.0f;
    private float DiagonalScroll = 1.0f;

    public float PanSpeed = 10.0f;

    // Zoom
    public Transform cameraTransform;
    public float zoomSpeed = 1.0f;
    public Vector2 zoomRange;


    void Update()
    {
        Movement();
        Zoom();
    }

    private void Movement()
    {

        if (Input.GetButton("Up"))
        {
            transform.Translate(transform.forward * Time.deltaTime * PanSpeed, Space.World);
        }
        else if (Input.GetButton("Down"))
        {
            transform.Translate(-transform.forward * Time.deltaTime * PanSpeed, Space.World);
        }

        if (Input.GetButton("Right"))
        {
            transform.Translate(transform.right * Time.deltaTime * PanSpeed, Space.World);
        }
        else if (Input.GetButton("Left"))
        {
            transform.Translate(-transform.right * Time.deltaTime * PanSpeed, Space.World);
        }
    }

    private void Zoom()
    {
        float mouseScroll = Input.GetAxis("MS");

        Vector3 pos = transform.position + cameraTransform.forward * Time.deltaTime * mouseScroll * zoomSpeed;

        if(pos.y > zoomRange.x && pos.y < zoomRange.y)
        {
            transform.position = pos;
        }
    }
}
