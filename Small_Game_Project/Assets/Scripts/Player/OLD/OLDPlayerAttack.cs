using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDPlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 5f;
    public int attackDamage = 20;

    bool SpearWeapon = false;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpearWeapon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        SpearToggle();
    }
    void SpearToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpearWeapon = !SpearWeapon;
            animator.SetTrigger("hasSpear");
        }
    }

    void Attack()
    {
        if(SpearWeapon)
        {
            Debug.Log("I Have Attacked!");
            // Set attack animation

            animator.SetTrigger("ThrowSpear");
            // Detect enemies in range of attack
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            // Damage them
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
