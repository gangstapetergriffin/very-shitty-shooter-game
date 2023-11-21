using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float CurrentSpeed;
    public float WalkingSpeed = 10f;
    public float RunningSpeed = 20f;

    public float Gravity = -0.2f;
    public float JumpSpeed = 0.1f;
    private float BaseLineGravity;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = WalkingSpeed;
        BaseLineGravity = Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * CurrentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * CurrentSpeed * Time.deltaTime;

        move = transform.right * moveX +
            transform.up * Gravity +
            transform.forward * moveZ;
        characterController.Move(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = RunningSpeed;
        }
        else
        {
            CurrentSpeed = WalkingSpeed;
        }

        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            Gravity = BaseLineGravity;
            Gravity *= -JumpSpeed;
        }
        if (Gravity > BaseLineGravity)
        {
            Gravity -=0.5f * JumpSpeed * Time.deltaTime;
        };
    }
}
