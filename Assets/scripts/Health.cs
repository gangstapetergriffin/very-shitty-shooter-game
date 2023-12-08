using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TMP_Text healthbar;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.text = "Health: " + health + "HP";
    }

    void colortext()
    {
        healthbar.color = Color.white;
        healthbar.transform.localRotation = Quaternion.AngleAxis(0,new Vector3(0, 0, 0));
    }
    public void DealDamage( int amount)
    {
        health = health - amount;
        healthbar.text = "Health: " + health + "HP";
        if (health <= 0) {
            healthbar.text = "Game Over";
            Invoke("LoadMainMenu", 5);
        }
        healthbar.color = Color.red;
        int rndnumber = Random.Range(-10, 10);
        healthbar.transform.localRotation = Quaternion.AngleAxis(rndnumber,Vector3.forward);
        Invoke("colortext", 0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
        
    }
}
