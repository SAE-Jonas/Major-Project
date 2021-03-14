using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Movement : MonoBehaviour
{
    public float moveSpeed;
    public bool GamepadConnected;
    private Rigidbody GhostRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        GhostRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput * moveSpeed;

        if (!GamepadConnected)
        {
            Plane VirtualTable = new Plane(Vector3.up, Vector3.zero);
        }

        if (GamepadConnected)
        {
            Vector3 Direction = Vector3.right * Input.GetAxisRaw("HorizontalR3") + Vector3.forward * -Input.GetAxisRaw("VerticalR3");

            if (Direction.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
            }
        }
    }

    private void FixedUpdate()
    {
        GhostRigidbody.velocity = moveVelocity;
    }
}
