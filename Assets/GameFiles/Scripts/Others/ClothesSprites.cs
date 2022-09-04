using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSprites : MonoBehaviour
{
    
    /*
    
    Objective: Store the clothes Sprites for other scripts use.
    
    Alternatives: if I need to swap between scenes I can turn this script in static or don't destroy on load. but I don't need in this games.
    
    */
    
    
    public PlayerInventory player;
    public List<Sprite> sprites;
    
    void FixedUpdate()
    {
        if(player == null)
            player =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
}
