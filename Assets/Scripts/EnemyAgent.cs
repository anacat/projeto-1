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

    private float _initialAngularSpeed;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _initialAngularSpeed = _agent.angularSpeed;
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

        if (_isOnLadder && _agent.isOnOffMeshLink && !_animator.GetBool("isClimbing"))
        {
            _animator.SetBool("isClimbing", true);
            _agent.speed = 0.5f;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isOnLadder = true;
            _agent.angularSpeed = 0f;
        }
        
        if (other.CompareTag("LadderEnd"))
        {
            _isOnLadder = false;
            
            _animator.SetBool("isClimbing", false);
            _agent.speed = 3.5f;
            _agent.angularSpeed = _initialAngularSpeed;
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
