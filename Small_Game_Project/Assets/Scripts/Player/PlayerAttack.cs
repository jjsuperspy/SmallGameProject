using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 5f;
    public int attackDamage = 20;

    bool ToggleWeapon = false;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ToggleWeapon = false;
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
        

        WeaponToggle();
    }
    void WeaponToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleWeapon = !ToggleWeapon;
            animator.SetBool("Toggle_Weapon", ToggleWeapon);
        }
    }

    void Attack()
    {
        if(ToggleWeapon)
        {
            Debug.Log("I Have Attacked!");
            // Set attack animation

            animator.SetTrigger("isAttacking");
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
