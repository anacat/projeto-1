using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para o canvas do inimigo funcionar como um bilboard - sempre virado na direção do jogador
public class CanvasLookAt : MonoBehaviour
{
    public Transform lookAt;

    void Update()
    {
        transform.LookAt(lookAt);
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f); //prende a rotação só em y
    }
}
