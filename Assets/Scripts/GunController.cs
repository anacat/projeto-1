using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float shootingDistance;
    public Transform muzzle;
    public GameObject bulletTrailPrefab;
    public float fireDelay = 0.1f;

    public int damage = 5;

    private Camera _camera;
    private float _lastShotTime = 0f;

    public Animator animator;
    public bool hideAnimationEnded;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
       _camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (InputController.Instance.PlayerShotInThisFrame()) //se não tiver PlayerInput nos components do jogador/para utilizar o InputController
        {
            Shoot();
        }
    }

    private void OnShoot() //definido pelo PlayerInput/qd pressiona o botão esq do rato
    {
        Shoot();
    }

    private void Shoot()
    {
        if (PlayerController.Instance.isDead)
        {
            return;
        }
        
        bool canShoot = Time.time - _lastShotTime > fireDelay && meshRenderer.enabled;

        if (!canShoot)
        {
            return;
        }

        //Input.mousePosition //inputController.GetMousePosition()
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingDistance))
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyController>().GotShot(damage);
                //Destroy(hit.transform.gameObject);
            }
        }
        
        StartCoroutine(BulletTrail(hit, ray));

        //Debug.DrawRay(ray.origin, ray.direction * shootingDistance, Color.red, 5f);

        _lastShotTime = Time.time;
    }

    private IEnumerator BulletTrail(RaycastHit hit, Ray ray)
    {
        float percentage = 0f;
        float time = 0f;
        float timer = 0f;
        
        Vector3 startPosition = muzzle.position;
        Vector3 finalPosition;
        
        if (hit.collider == null)
        {
            finalPosition = ray.origin + ray.direction * shootingDistance; //se não acertar num objeto, segue a direção do raio do raycast
        }
        else
        {
            finalPosition = hit.point; //se acertar nalgum objeto, a posição final será o ponto de colisão
        }

        GameObject newTrail = Instantiate(bulletTrailPrefab, transform.position, transform.rotation);
        time = newTrail.GetComponent<TrailRenderer>().time;

        while (percentage < 1f)
        {
            timer += Time.deltaTime;
            percentage = timer / time;

            newTrail.transform.position = Vector3.Lerp(startPosition, finalPosition, percentage);
            
            yield return null;
        }
    }

    public void OnHideAnimationEnded() //evento chamado no final da animação de hide da arma (ver aba de animation da arma no unity)
    {
        meshRenderer.enabled = false; //escondemos a mesh em vez de desativar o gameobject, para evitar problemas com o animator
        hideAnimationEnded = true;
    }
}
