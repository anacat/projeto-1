using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public PlayerInventory inventory;

    public void Start()
    {
        inventory.ClearInventory();
    }
    
    public void CaughtItem(GameItem itemData)
    {
        inventory.AddToInventory(itemData);
    }
}
