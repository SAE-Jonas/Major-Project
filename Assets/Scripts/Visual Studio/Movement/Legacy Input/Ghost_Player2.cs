using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Player2 : MonoBehaviour
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
        moveInput = new Vector3(-Input.GetAxisRaw("Horizontal2"), 0.0f, Input.GetAxisRaw("Vertical2"));

        moveVelocity = moveInput * moveSpeed;
    }

    private void FixedUpdate()
    {
        GhostRigidbody.velocity = moveVelocity;
    }
}
