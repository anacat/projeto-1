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
    
    void Start()
    {
        healthBar.maxValue = maxHp;
        healthBar.minValue = 0;

        healthBar.value = hp;
    }

    public void GotShot(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, maxHp);

        healthBar.value = hp;

        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
