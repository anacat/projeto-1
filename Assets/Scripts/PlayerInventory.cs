using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<GameItem> inventoryList = new List<GameItem>();

    public void AddToInventory(GameItem item)
    {
        inventoryList.Add(item);
    }

    public void RemoveFromInventory(GameItem item)
    {
        inventoryList.Remove(item);
    }

    public void ClearInventory()
    {
        inventoryList.Clear();
    }
}
