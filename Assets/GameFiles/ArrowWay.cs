using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWay : MonoBehaviour
{
    public bool isClose;
    public SpriteRenderer sprite;
    public Transform target;
    public Transform arrowPosition;
    
    
    public GameObject[] menus;
    // Update is called once per frame
    void Update()
    {
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

