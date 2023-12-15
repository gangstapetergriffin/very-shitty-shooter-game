using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject OGEnemy;
    public float EnemyMax = 400;
    public TMP_Text enemAmount;
    public TMP_Text Wave;
    public GameObject[] Spawnpoints;
    public Vector3[] Positions;
    private int waves = 1;
    private int enemiesAlive = 0;
    private bool wavestart;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnZombies", 10);
    }

    void spawnZombies()
    {
        wavestart = true;
        Positions = new Vector3[Spawnpoints.Length];
        for (int i = 0; i < Spawnpoints.Length; i++)
        {
            Positions[i] = Spawnpoints[i].transform.position;
        }
        for (int b = 0; b < EnemyMax; b++)
        {
            int randomIndex = Random.Range(0, Spawnpoints.Length);
            GameObject enemy = Instantiate(OGEnemy, Positions[randomIndex], Quaternion.identity);
        }
    }

    private void Update()
    {
        int enemiesAlive = GameObject.FindGameObjectsWithTag("NPC").Length;

        enemAmount.text = "Enemies Alive: " + enemiesAlive.ToString();
        if (enemiesAlive == 0 && (wavestart == true))
        {
            wavestart = false;
            waves++;
            EnemyMax = EnemyMax * 1.5f;
            Invoke("spawnZombies",3);
            Wave.text = "Wave: " + waves;

        }
    }

}
