using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWay : MonoBehaviour
{
    
    /*
    
    Objective: Control the arrow for easy location by player.
    
    */
    
    public bool isClose;
    public SpriteRenderer sprite;
    public Transform target;
    public Transform arrowPosition;
    
    
    public GameObject[] menus;
    public bool noObejectives;
    void FixedUpdate()
    {
        if(noObejectives)
        {
            sprite.enabled = false;
            return;
        }
        
        transform.position = arrowPosition.position;
        transform.up = target.position - transform.position;
        
        if(Vector3.Distance(transform.position, target.position) < 0.7f)
        {
            isClose = true;
            sprite.enabled = false;
        }else
        {
            isClose = false;
            sprite.enabled = true;
        }
        if(!isClose)
            if(menus[0].activeInHierarchy || menus[1].activeInHierarchy || menus[2].activeInHierarchy)
                sprite.enabled = false;
            else
                sprite.enabled = true;
   
            
    }
}

