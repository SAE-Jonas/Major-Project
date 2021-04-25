using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -98.1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool Witch;
    public bool Ghost;
    public WitchStaff Staff;

    public int RunesCollected;
    public bool LaserProjectile;

    public float timeRemaining = 10;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (RunesCollected >= 2)
        {
            if (Witch)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {

                    LaserProjectile = true;

                }

                if (LaserProjectile)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Staff.isFiring = true;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        Staff.isFiring = false;
                    }

                    if (timeRemaining > 0)
                    {
                        timeRemaining -= Time.deltaTime;
                    }
                    else
                    {
                        Debug.Log("Time has run out");
                        RunesCollected = RunesCollected - 2;
                        LaserProjectile = false;
                        timeRemaining = 10;
                    }
                }
            }

            if (Ghost)
            {
                speed = speed + 2;

                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time has run out");
                    RunesCollected = 0;
                }
            }
        }
    }
}
