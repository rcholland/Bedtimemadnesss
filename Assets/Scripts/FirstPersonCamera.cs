using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    [SerializeField]
    private GameObject mainCamera;

    public float mouseSensitivity = 500.0f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis(xAxis) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(yAxis) * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60.0f, 60.0f);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * mouseX);

    }
}
