using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public InputController inputController;
    public float shootingDistance;
    public Transform muzzle;
    public GameObject bulletTrailPrefab;
    public float fireDelay = 0.1f;

    private Camera _camera;
    private float _lastShotTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
       _camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (inputController.PlayerShotInThisFrame()) //se não tiver PlayerInput nos components do jogador/para utilizar o InputController
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
        bool canShoot = Time.time - _lastShotTime > fireDelay;

        if (!canShoot)
        {
            return;
        }

        //Input.mousePosition //inputController.GetMousePosition()
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingDistance))
        {
            Debug.Log(hit.collider.name);
            StartCoroutine(BulletTrail(hit));
        }
        
        //Debug.DrawRay(ray.origin, ray.direction * shootingDistance, Color.red, 5f);

        _lastShotTime = Time.time;
    }

    private IEnumerator BulletTrail(RaycastHit hit)
    {
        float percentage = 0f;
        float time = 0f;
        float timer = 0f;
        
        Vector3 startPosition = muzzle.position;
        Vector3 finalPosition = hit.point;

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
}
