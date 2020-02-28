using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public CapsuleCollider collider1;
    public CapsuleCollider collider2;

    public Component move;

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

        collider1.enabled = false;
        collider2.enabled = false;
        move.enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;

    }
}
