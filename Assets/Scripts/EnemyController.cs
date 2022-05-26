using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int hp;
    public int maxHp;

    public Slider healthBar;

    public GameObject ragdoll;

    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;

    private float _projectileTimer;
    public float attackTime;

    void Start()
    {
        healthBar.maxValue = maxHp;
        healthBar.minValue = 0;

        healthBar.value = hp;
    }

    private void Update()
    {
        _projectileTimer += Time.deltaTime;

        if (_projectileTimer > attackTime)
        {
            //Spawn Projectile
            ShootProjectile();            
            _projectileTimer = 0f;
        }

        transform.LookAt(PlayerController.Instance.transform);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }

    private void ShootProjectile()
    {
        GameObject projectile =
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        
        Rigidbody bRigidbody = projectile.GetComponent<Rigidbody>();
        bRigidbody.velocity = (projectile.transform.forward * 5f) + new Vector3(0f, 5f, 0);
    }

    public void GotShot(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);

        healthBar.value = hp;

        if (hp == 0)
        {
            Vector3 dir = transform.position - PlayerController.Instance.transform.position;

            GameObject rd = Instantiate(ragdoll, transform.position, transform.rotation); //instancia ragdoll
            rd.GetComponent<RagdollController>().ApplyForce(dir * 20f);
            
            Destroy(gameObject);
        }
    }
}