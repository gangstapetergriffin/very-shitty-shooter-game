using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform player;
    public float AttackRange = 10;
    public float DamageRange = 1.5f;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;
    private GameObject PlayerGO;
    public bool foundPlayer;
    private bool PlayerDamage;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
         
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Demage()
    {
        PlayerDamage = false;
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
        if (Vector3.Distance(transform.position, player.position) <= DamageRange && PlayerDamage == false)
        {
            PlayerDamage = true;
            PlayerGO.GetComponent<Health>().DealDamage(Random.Range(0, 10));
            Invoke("Demage", 0.8f);
        }
    }
}
