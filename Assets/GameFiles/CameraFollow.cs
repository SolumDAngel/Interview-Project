using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 heightLimit, widthLimit;
    
    public Transform target;
    
    public  bool x,y;
    public float speed;

    void Start()
    {
        
    }


    void LateUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
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
            {
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
                    //new Vector3 (Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime).x, transform.position.y,transform.position.z);
            }
            if(y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
                    //new Vector3 (transform.position.x ,Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime).y ,transform.position.z);
            }
            
        }
    }
    

}
