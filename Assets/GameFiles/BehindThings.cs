using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindThings : MonoBehaviour
{
    public int playerDefaultLayer;
    public int targetLayerForPlayer;
    
    public SpriteRenderer player;
   

    public bool isCollinding;

    void Start()
    {
        
    }


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
