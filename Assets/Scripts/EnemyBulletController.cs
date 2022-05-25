using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float lifeTime;
    
    private float _timer;
    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<PlayerController>().ReceiveDamage(5);
                Destroy(gameObject);
                break;
        }
    }
}
