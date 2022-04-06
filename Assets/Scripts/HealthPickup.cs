using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup //Pickup já herda de Monobehaviour
{
    public int health;
    
    protected override void OnPlayerTrigger(PlayerController player)
    {
        Debug.Log("Player trigger");
        player.CaughtHealthPickup(health);
        
        base.OnPlayerTrigger(player);
    }
}
