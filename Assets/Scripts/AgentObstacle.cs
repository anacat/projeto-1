using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AgentObstacle : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _canMove;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 2f)
        {
            _canMove = !_canMove;
            _timer = 0f;
        }
        
        if (_canMove)
        {
            transform.position = _initialPosition + new Vector3(Mathf.Sin(_timer * 2f), 0);
        }
    }
}
