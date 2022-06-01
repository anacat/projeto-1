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
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isOnLadder = true;
            _agent.angularSpeed = 0f;
            _agent.speed = 0f;

            StartCoroutine(LerpToPosition(other.transform.position, other.transform.eulerAngles));
        }
        
        if (_isOnLadder && other.CompareTag("LadderEnd"))
        {
            _isOnLadder = false;
            
            _animator.SetBool("isClimbing", false);
            _agent.speed = 3.5f;
            _agent.angularSpeed = _initialAngularSpeed;
        }
    }

    private IEnumerator LerpToPosition(Vector3 position, Vector3 rotation)
    {
        float timer = 0f;
        float percentage = 0f;
        float time = 0.1f;

        float distance = Vector3.Distance(transform.position, position);
        Debug.Log(distance);
        
        time *= distance;

        Vector3 initialPosition = transform.position;
        Vector3 initialRotation = transform.eulerAngles;

        while (percentage < 1f)
        {
            timer += Time.deltaTime;
            percentage = timer / time;
            
            transform.position = Vector3.Lerp(initialPosition, position, percentage);
            transform.eulerAngles = Vector3.Lerp(initialRotation, rotation, percentage );
            
            yield return null;
        }
        
        if (_isOnLadder && _agent.isOnOffMeshLink && !_animator.GetBool("isClimbing"))
        {
            _animator.SetBool("isClimbing", true);
            _agent.speed = 0.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isOnLadder = false;
            _animator.SetBool("isClimbing", false);
            _agent.speed = 3.5f;
            _agent.angularSpeed = _initialAngularSpeed;
        }
    }
}
