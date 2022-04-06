using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;
    
    private float _timer;
    
    void Update()
    {
        //tempo de vida da bala
        
        _timer += Time.deltaTime;

        if (_timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Enemy":
                collision.collider.GetComponent<EnemyController>().GotShot(5);
                break;
            default:
                break;
        }

        Destroy(gameObject);
    }
}
