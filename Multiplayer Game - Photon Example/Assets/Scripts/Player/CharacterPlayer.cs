using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "MultiplayerGame/Character", order = 1500)]
public class CharacterPlayer : ScriptableObject
{
    public int id;
    public PlayerStats playerStats;
    public Sprite uiSprite;
    public GameObject playerObject;
    
}
