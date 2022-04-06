using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gere a troca de armas
public class WeaponManager : MonoBehaviour
{
    public PistolController pistolController;
    public GunController gunController;
    
    void Update()
    {
        //Troca pistol pela gun; Tecla 2
        if (InputController.Instance.Weapon2() && pistolController.meshRenderer.enabled) //se trocarmos para a arma 2 e a arma 1 estiver ativa
        {
            pistolController.animator.SetTrigger("hide");
        }

        if (pistolController.hideAnimationEnded && 
            !gunController.meshRenderer.enabled &&
            !pistolController.meshRenderer.enabled) //se estivermos a trocar para a arma 2 e a animação da arma 1 acabou
        {
            gunController.meshRenderer.enabled = true;
            gunController.animator.SetTrigger("show");
            
            pistolController.hideAnimationEnded = false; //damos reset à variável que verifica se a animação já acabou
        }

        //Troca gun pela pistol; Tecla 1
        if (InputController.Instance.Weapon1() && gunController.meshRenderer.enabled)
        {
            gunController.animator.SetTrigger("hide");
        }

        if (gunController.hideAnimationEnded && 
            !pistolController.meshRenderer.enabled &&
            !gunController.meshRenderer.enabled)
        {
            pistolController.meshRenderer.enabled = true;
            pistolController.animator.SetTrigger("show");
            
            gunController.hideAnimationEnded = false; //damos reset à variável que verifica se a animação já acabou
        }
    }
}
