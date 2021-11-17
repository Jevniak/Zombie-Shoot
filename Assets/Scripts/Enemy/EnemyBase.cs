using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    protected virtual void Die()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        gameObject.layer = 2;
    }

    protected virtual void MoveToTarget(NavMeshAgent agent, Transform targetTransform)
    {
        agent.SetDestination(targetTransform.position);
    }
}
