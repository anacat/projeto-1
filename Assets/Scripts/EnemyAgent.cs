using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public Transform target;

    private Animator _animator;
    private NavMeshAgent _agent;
    private bool _isDead;
    private bool _isOnLadder;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _agent.SetDestination(target.position);

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Debug.Log("reached player");
        }

        if (InputController.Instance.SpawnEnemyButton())
        {
            _agent.isStopped = !_agent.isStopped;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isOnLadder = true;
            _animator.SetBool("isClimbing", true);
            _agent.speed = 0.5f;
        }
        
        if (other.CompareTag("LadderEnd"))
        {
            _isOnLadder = true;
            _animator.SetBool("isClimbing", false);
            _agent.speed = 3.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isOnLadder = false;
        }
    }
}
