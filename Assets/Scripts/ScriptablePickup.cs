using System;
using UnityEngine;

    public class ScriptablePickup : Pickup
    {
        public GameItem itemInfo;

        protected override void OnPlayerTrigger(PlayerController player)
        {
            Debug.Log("Player trigger");
            
            //coloca o item no inventario
            player.GetComponent<PlayerInventoryController>().CaughtItem(itemInfo);

            base.OnPlayerTrigger(player);
        }
    }