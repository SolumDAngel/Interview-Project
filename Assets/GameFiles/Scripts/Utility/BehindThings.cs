using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindThings : MonoBehaviour
{
    
    /*
    
    Objective: Put the player behind structure by collision.
    
    obs: I don't have much experience in 2D TopDown.
    Ordering Layer is a thing I don't get complete yet.
    
    */
    
    
    public int playerDefaultLayer;
    public int targetLayerForPlayer;
    
    public SpriteRenderer player;
   

    public bool isCollinding;


    void FixedUpdate()
    {
        if(player != null)
        if(isCollinding)
        {
            player.sortingOrder = targetLayerForPlayer;
        }
    }

    protected void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = other.GetComponent<SpriteRenderer>();
            isCollinding = true;
        }
    }
    protected void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = other.GetComponent<SpriteRenderer>();
            isCollinding = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D other) {
     if(other.CompareTag("Player")){
         player.sortingOrder = playerDefaultLayer;
         player = null;
         isCollinding = false;
     }
    }
}
