using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float X_Mouse = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float Y_Mouse = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= Y_Mouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * X_Mouse);
    }
}
