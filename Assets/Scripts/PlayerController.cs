using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    
    public int hp;
    public int maxHp;

    private float collisionDelay = 0.5f;
    private float collisionTimer;

    public bool isDead;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else if (Instance == null)
        {
            Instance = this;
        }

        GameSave gameStats = new GameSave();
        gameStats.coinsCaught = 2;

        if (SaveManager.DoesSaveFileExist())
        {
            gameStats = SaveManager.Load();
        }
        else
        {
            Debug.Log("no save file");
        }
        
        SaveManager.SaveGame(gameStats);
    }

    private void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHp;
            healthSlider.minValue = 0;
            healthSlider.value = hp;

            healthText.text = hp + "/" + maxHp;
        }
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

    public void ReceiveDamage(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);
            
        healthSlider.value = hp;
        healthText.text = hp + "/" + maxHp;
    }

    private IEnumerator TimerTest()
    {
        yield return new WaitForSeconds(1f);

        //codigo
    }
}
