using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interect : MonoBehaviour
{
    
    /*
    
    Objective: Simple Interact Sytem.
    
    */
    
    [HideInInspector]
    public GameObject player;
    public float minDistance;
    public bool interacted;
    
    public GameObject buttonImage;
    public GameObject activeDesactiveObject;
   
    void Update()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        else
        {
            if(Vector2.Distance(transform.position, player.transform.position) < minDistance)
            {
                if(interacted == false)
                    buttonImage.SetActive(true);
                else
                    buttonImage.SetActive(false);
               
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interacted = !interacted;
                    if(activeDesactiveObject != null)
                    activeDesactiveObject.SetActive(interacted);
                }
            }else
            {
                interacted = false;
                if(activeDesactiveObject != null)
                activeDesactiveObject.SetActive(interacted);
                buttonImage.SetActive(false);
            }
        }
    }
}
