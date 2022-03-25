using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public InputController inputController;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (inputController.PlayerShotInThisFrame())
        {
            ShootRaycast();
        }
    }

    private void ShootRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputController.GetMousePosition());
        RaycastHit hit;

        bool hasHitSomething = Physics.Raycast(ray, out hit, 100f);

        if (hasHitSomething && hit.collider != null)
        {
            Debug.Log(hit.transform.name);
        }
    }
}
