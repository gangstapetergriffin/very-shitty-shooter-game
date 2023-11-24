using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject OGEnemy;
    public int EnemyMax = 400;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnemyMax; i++)
        {
            GameObject enemy = Instantiate(OGEnemy);
        }
    }

}
