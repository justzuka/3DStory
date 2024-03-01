using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraZu : MonoBehaviour
{
    public float size = 2;
    public Transform cam;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * size;
        float verticalInput = Input.GetAxis("Vertical") * size;


        Vector3 dir = new Vector3(horizontalInput, 0f, verticalInput);
        Quaternion filteredRotation = new Quaternion(0f, cam.transform.rotation.y, 0f, cam.transform.rotation.w);
        dir = filteredRotation * dir;
        if (dir.magnitude > 1) dir = Vector3.Normalize(dir);
        transform.position = dir;
    }
}
