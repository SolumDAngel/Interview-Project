using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    /*
    
    Objective: Camera Follow the player and stop on borders.
    
    obs: this is the easier way I find;
    
    */
    
    public Vector2 heightLimit, widthLimit;
    
    public Transform target;
    
    public  bool x,y;
    public float speed;

    void LateUpdate()
    {
        if(target == null)
        
            target = GameObject.FindGameObjectWithTag("Player").transform;
        
        else
        {
            if(target.position.x > widthLimit.x && target.position.x < widthLimit.y)
                x = true;
            else
                x = false;
               
            if( target.position.y > heightLimit.x && target.position.y < heightLimit.y)
                y = true;
            else
                y = false;
          
         
            if(x)
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            if(y)
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            
        }
    }
    

}
