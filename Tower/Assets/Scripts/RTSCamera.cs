using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float speed = 30.0f;
    public float scrollSpeed = 100.0f;

    public float rotateAmount = 10.0f;
    public float rotateSpeed = 300.0f;

    public float panBorderThickness = 10.0f;

    private bool isMoveable = true;

    public float minY = 5.0f;
    public float maxY = 80.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
    }

    private void MoveCamera()
    {
        float mx = Input.mousePosition.x;
        float my = Input.mousePosition.y;

        if (Input.GetButton("Up") || my > Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetButton("Down") || my < panBorderThickness)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetButton("Right") || mx > Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetButton("Left") || mx < panBorderThickness)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // Somehow the scrolling is not-responsive

        float scroll = Input.GetAxis("MS");

        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    private void RotateCamera()
    {
        Vector3 rot = transform.eulerAngles;

        if (Input.GetMouseButton(1))
        {     
            //rot.x -= Input.GetAxis("Mouse Y") * rotateAmount * Time.deltaTime;
            rot.y += Input.GetAxis("Mouse X") * rotateAmount * Time.deltaTime;
            //rot.z += Input.GetAxis("Mouse X") * rotateAmount * Time.deltaTime;

            transform.eulerAngles = rot;
        }

    }
}
