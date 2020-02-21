using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int currenthealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currenthealth -= damage;

        healthBar.SetHealth(currenthealth);
    }
}
