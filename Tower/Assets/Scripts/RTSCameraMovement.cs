﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraMovement : MonoBehaviour
{
    public float ScrollSpeed = 15.0f;
    public float ScrollEdge = 0.03f;

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
        Zoom();
        Movement();
    }

    private void Movement()
    {
        float speedFactor = transform.position.y / zoomRange.y;

        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        if (Input.GetButton("Up") || mouseY > (1F - ScrollEdge) * Screen.height)
        {
            transform.Translate(transform.forward * Time.deltaTime * speedFactor * PanSpeed, Space.World);
        }
        else if (Input.GetButton("Down") || mouseY < ScrollEdge * Screen.height)
        {
            transform.Translate(-transform.forward * Time.deltaTime * speedFactor * PanSpeed, Space.World);
        }

        if (Input.GetButton("Right") || mouseX > (1F - ScrollEdge) * Screen.width)
        {
            transform.Translate(transform.right * Time.deltaTime * speedFactor * PanSpeed, Space.World);
        }
        else if (Input.GetButton("Left") || mouseX < ScrollEdge * Screen.width)
        {
            transform.Translate(-transform.right * Time.deltaTime * speedFactor * PanSpeed, Space.World);
        }
    }

    private void Zoom()
    {
        float mouseScroll = Input.GetAxis("MS");

        Vector3 pos = transform.position + cameraTransform.forward * Time.deltaTime * mouseScroll * zoomSpeed;

        if (pos.y > zoomRange.x && pos.y < zoomRange.y)
        {
            transform.position = pos;
        }
    }
}
