using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform player;
    public float AttackRange = 10;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;

    public bool foundPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= AttackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemyMovement.enemy.SetDestination(player.position);
            foundPlayer = true;
        }
        else if(foundPlayer)
        {
            rend.sharedMaterial = defaultMaterial;
            enemyMovement.newLocation();
            foundPlayer = false;
        }
    }
}
