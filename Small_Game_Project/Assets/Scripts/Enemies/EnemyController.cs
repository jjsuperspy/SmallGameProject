using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    
    Transform player;
    NavMeshAgent agent;

    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Look at Player
        Vector3 rot = Quaternion.LookRotation(player.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);

        //Move to Player
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
