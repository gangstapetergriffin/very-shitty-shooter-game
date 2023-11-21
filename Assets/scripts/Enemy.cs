using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetDestination(new Vector3(10, 0, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
