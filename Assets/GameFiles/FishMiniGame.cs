using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishMiniGame : MonoBehaviour
{
    public float timeBetweenErrors;
    public float speedDificult;
    public float animatorSpeed;
    public bool exteriorArea, interiorArea;
   
    public Animator animator;
    public RectTransform handle;
    public PlayerInventory player;
    public TextMeshProUGUI text;



    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerInventory>();
    }

    float timing;
    bool invert;
    void Update()
    {
        if(timing > 0){
            timing -= 1 * Time.deltaTime;
            animator.speed = 0;
        }
        else
        {
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(exteriorArea)
                {
                    player.inventory.fishQuantity +=1;
                }
                
                if(interiorArea)
                {
                    player.inventory.fishQuantity +=1;
                }

                if(!exteriorArea && !interiorArea)
                {
                // player.inventory.fishQuantity = 0;
                timing = timeBetweenErrors;
                }
                    
                animator.Rebind();
                invert = !invert;
                animator.SetBool("Invert", invert);
            }   
            text.text = "Fish:" + player.inventory.fishQuantity;
            animatorSpeed = speedDificult + player.inventory.fishQuantity / 10;
            animator.speed = animatorSpeed;
        }
    }
}
