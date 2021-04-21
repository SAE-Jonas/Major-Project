using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch_Movement : MonoBehaviour
{
    public float moveSpeed;
    public bool GamepadConnected;
    public Rigidbody GhostRigidbody;
    public CharacterController controller;

    public WitchStaff Staff;

    public int RunesCollected;

    private Vector3 moveInput;
    private Vector3 moveVelocity;


    // Start is called before the first frame update
    void Start()
    {
        GhostRigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        moveInput = Camera.main.transform.TransformDirection(moveInput);
        moveInput.y = 0;

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

        if (RunesCollected == 2)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                Staff.isFiring = true;
            }

            if (Input.GetButtonUp("Shoot"))
            {
                Staff.isFiring = false;
            }

            //if (Input.GetKeyDown(KeyCode.JoystickButton14))
            //{
            //    Staff.isFiring = true;
            //}

            //if (Input.GetKeyUp(KeyCode.JoystickButton14))
            //{
            //    Staff.isFiring = false;
            //}
        }
    }

    private void FixedUpdate()
    {
        controller.SimpleMove(moveVelocity);
    }
}
