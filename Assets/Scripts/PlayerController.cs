using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    
    public int hp;
    public int maxHp;

    private float collisionDelay = 0.5f;
    private float collisionTimer;

    private void Start()
    {
        healthSlider.maxValue = maxHp;
        healthSlider.minValue = 0;
        healthSlider.value = hp;
        
        healthText.text = hp + "/" + maxHp;
        //healthText.text = String.Format("{0}/{1}", hp, maxHp); 
    }

    public void CaughtHealthPickup(int health)
    {
        hp += health;
        hp = Mathf.Clamp(hp, 0, maxHp);
        
        healthSlider.value = hp;
        healthText.text = hp + "/" + maxHp;
    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    //ao utilizar um CharacterController as colisões devem ser verificadas através da função OnControllerColliderHit
    //em vez do OnCollisionEnter
    //as colisões são geridas pelo CharacterController; n é necessário a adição de um collider nem de um rigidbody
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Enemy") && collisionTimer > collisionDelay)
        {
            hp -= 5;
            hp = Mathf.Clamp(hp, 0, maxHp);
            
            healthSlider.value = hp;
            healthText.text = hp + "/" + maxHp;

            collisionTimer = 0f;
        }
    }
}
