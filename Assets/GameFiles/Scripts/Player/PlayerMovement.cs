using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    /*
    Objective: Simple player movement.
    
    obs: can be better, but is waste of time for this project.
    */
    
    public SpriteRenderer sprite;
 
    public Vector3 direction;
    public Rigidbody2D rb;
    public float speed;
    public SortingGroup sortingGroup;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        sortingGroup = GetComponent<SortingGroup>();
        
    }
    void FixedUpdate()
    {
        sortingGroup.sortingOrder = sprite.sortingOrder;
    }

    void Update()
    {
        direction = Vector3.zero; 
        
        if(Input.GetKey(KeyCode.D))
            direction.x = 1;
        if(Input.GetKey(KeyCode.A))
            direction.x = -1;
        if(Input.GetKey(KeyCode.W))
            direction.y = 1;
        if(Input.GetKey(KeyCode.S))
            direction.y = -1;
            
        rb.AddForce(direction.normalized * speed * Time.deltaTime);
    }
}
