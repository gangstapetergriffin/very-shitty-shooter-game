using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float CurrentSpeed;
    public float WalkingSpeed = 10f;
    public float RunningSpeed = 15f;

    public float Gravity = -0.5f;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = WalkingSpeed;
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
    }
}
