using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSprites : MonoBehaviour
{
    public PlayerInventory player;
    public List<Sprite> sprites;
    
    void FixedUpdate()
    {
        if(player == null)
            player =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
}
