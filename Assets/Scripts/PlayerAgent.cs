using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.Instance.PlayerShotInThisFrame())
        {
            Ray ray = _mainCamera.ScreenPointToRay(InputController.Instance.GetMousePosition());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
        
        //Debug.Log("is jumping " + _agent.isOnOffMeshLink);
    }
}
