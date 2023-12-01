using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera Cam;

    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        {
            float rndAngleX = Random.Range(1, 10);
            float rndAngleY = Random.Range(1, 10);
            if (Input.GetMouseButtonDown(0))
            {
                ray = Cam.ScreenPointToRay(Input.mousePosition + new Vector3(rndAngleX, rndAngleY));
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.point);
                    if (hit.collider.tag.Equals("NPC"))
                    {
                        Debug.Log("hit npc");
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

    }
}
