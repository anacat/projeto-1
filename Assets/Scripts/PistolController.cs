using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunBarrel;

    public Animator animator;

    public bool hideAnimationEnded;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (InputController.Instance.PlayerShotInThisFrame())
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody bRigidbody = bullet.GetComponent<Rigidbody>();
        
        //bRigidbody.AddRelativeForce(new Vector3(0, 0, 5f), ForceMode.Impulse);
        bRigidbody.velocity = gunBarrel.forward * 50f;
        
        //devido à grande velocidade em que a bala se move, é necessário alterar a collision detection no rigidbody para conitnuous (no inspector)
        //caso contrário, a bala pode não detetar colisões
    }

    public void OnHideAnimationEnd() //evento chamado no final da animação de hide da arma (ver aba de animation da arma no unity)
    {
        //Debug.Log("animation hide ended");
        meshRenderer.enabled = false; //escondemos a mesh em vez de desativar o gameobject, para evitar problemas com o animator
        hideAnimationEnded = true;
    }
}
