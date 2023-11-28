using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsway : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Header("Sway Settings")]

    [SerializeField] private float smooth;

    [SerializeField] private float swayMultiplier;

    float swayCounter = 0f;
    float swayMagnitude = .01f;

    // Update is called once per frame
    void Update()
    {
        // static hand movement for the gun model
        float addAmount = Mathf.Sin(0.01f * swayCounter) * swayMagnitude * Time.deltaTime;
        transform.localPosition += Vector3.up * addAmount;
        swayCounter++;

        // we want to have the mouse inpoot :3
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;

        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        // calculate the target rotation
        Quaternion rotationX = Quaternion.AngleAxis(mouseY, Vector3.left);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);


        Quaternion targetRotation = rotationX * rotationY;

        // finally rotate the weapon
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

    }
}
