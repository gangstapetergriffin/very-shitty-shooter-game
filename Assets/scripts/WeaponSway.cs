using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsway : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    [Header("Sway Settings")]

    [SerializeField] private float smooth;

    [SerializeField] private float swayMultiplier;

    float bobbingCounter = 0f;
    float bobbingMagnitude = .01f;
    [Header("Sway Settings")]
    public float GunRecoilAmount;
    public float RecoilSmooth;

    // Update is called once per frame
    void Update()
    {

        // static hand movement for the gun model
        float addAmount = Mathf.Sin(0.01f * bobbingCounter) * bobbingMagnitude * Time.deltaTime;
        transform.localPosition += Vector3.up * addAmount;
        bobbingCounter++;



        // we want to have the mouse inpoot :3
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;

        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        float mouseZ = Input.GetAxisRaw("Mouse X") * swayMultiplier * 0.5f;

        // calculate the target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.left);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotationZ = Quaternion.AngleAxis(mouseZ, Vector3.forward);


        Quaternion targetRotation = rotationX * rotationY * rotationZ;


        // finally rotate the weapon
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

        Quaternion GunRecoil = Quaternion.AngleAxis(GunRecoilAmount, Vector3.left);

        if (Input.GetMouseButtonDown(0))
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, GunRecoil, RecoilSmooth * 2);
        }
    }
}
