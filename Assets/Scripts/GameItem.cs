using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameItem", menuName = "ScriptableObjects/Game Item")]
public class GameItem : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string description;
}
