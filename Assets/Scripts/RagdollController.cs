using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody hip;
    
    void Start()
    {
        
    }

    public void ApplyForce(Vector3 forceDirection)
    {
        hip.AddForce(forceDirection, ForceMode.Impulse);
    }
}
