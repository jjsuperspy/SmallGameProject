using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // damage animation

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        // Die animation

        // Disable enemy

        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().isStopped = true;
        this.enabled = false;

        Destroy(this.gameObject, 2f);
    }
}
