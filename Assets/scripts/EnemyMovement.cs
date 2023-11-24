using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent enemy;
    public float SquareOfMovement = 50f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosition;
    private float yPosition;
    private float zPosition;
    public float closeEnough = 2;

    // Start is called before the first frame update
    void Start()
    {
        xMin = -SquareOfMovement;
        xMax = SquareOfMovement;
        zMin = -SquareOfMovement;
        zMax = SquareOfMovement;
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
        };
    }

    public void newLocation()
    {
        yPosition = transform.position.y;
        xPosition = Random.Range(xMin, xMax);
        zPosition = Random.Range(zMin, zMax);

        enemy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
