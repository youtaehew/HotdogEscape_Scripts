
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Enemy _enemy;
    public NavMeshAgent _navAgent;
    public Rigidbody _rigidbody;


    public void SetDestination(Vector3 destination)
    {
        if (_navAgent.enabled == false) return;
        _navAgent.isStopped = false;
        _navAgent.SetDestination(destination);
    }


}
