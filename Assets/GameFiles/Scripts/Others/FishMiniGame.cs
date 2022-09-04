using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishMiniGame : MonoBehaviour
{
    
    /*
    
    Objective: Fish Minigame to get fish and sell for money.
    
    Obs: I use Animation for this because I get strange results while use Mathf.Lerp, Mathf.LerpUnclamped and Mathf.MoveTowards.
    the results using are very strange for some reason I don't know yet.
    
    Exemple of the Code I used: bar.value = Mathf.lerp(0, 1f, speedDificult * Time.deltatime);
    i don't have much time know why this give me inconsistent result and don't make any smooth movement.
    
    */
    
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
                    player.inventory.fishQuantity +=1;
                
                if(interiorArea)
                    player.inventory.fishQuantity +=1;

                if(!exteriorArea && !interiorArea)
                {
                    // turOn the linebelow and the game will be more dificulty, but I get some bugs with objectives and I don't have more time to fix.
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
