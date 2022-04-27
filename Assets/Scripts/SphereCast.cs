using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, 10f, layerMask);

        for (int i = 0; i < collisions.Length; i++)
        {
            if (collisions[i].CompareTag("Enemy"))
            {
                //qq coisa
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
