using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;


    public Transform spearSpawn;
    public Rigidbody Spear;

    public float speed = 10f;

    bool SpearWeapon;
    bool ThrowSpear = false;


    // Start is called before the first frame update
    void Start()
    {
        SpearWeapon = false;
        ThrowSpear = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpearToggle();
        SpearThrow();
    }

    void SpearToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpearWeapon = !SpearWeapon;
            animator.SetBool("hasSpear", SpearWeapon);
        }
    }

    public void SpearThrow()
    {
        if(SpearWeapon)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ThrowSpear = !ThrowSpear;
                animator.SetTrigger("throwSpear");

                yeild WaitForSeconds(AnimationEvent);
                Rigidbody spearInstance;
                spearInstance = Instantiate(Spear, spearSpawn.position, spearSpawn.rotation) as Rigidbody;
                spearInstance.velocity = spearSpawn.TransformDirection(Vector3.up * speed);
            }
        }
        
    }
}
