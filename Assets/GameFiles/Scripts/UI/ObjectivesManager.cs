using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    /*
    
    Objective: Make the objectives.
    
    obs: I don't have much time when create this, can be a lot better and less polluted
    but I make using the only reasoning I get that time.
    
    */
    
    
    [HideInInspector] public ArrowWay arrowWay;
    [HideInInspector] public PlayerInventory playerInventory;
  
    public int objectiveNumber;
    public TextMeshProUGUI[] objectivesText;
    
    public int fish, maxFish;
    public int sellFish, maxSellFish;
    public int clothes, maxClothes;
    
    public Transform[] arrowTargets;
  
    void Start()
    {
        playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
        arrowWay = GameObject.FindObjectOfType<ArrowWay>();
    }

  
    void FixedUpdate()
    {
        if(objectiveNumber == 0)
        {
            fish = playerInventory.inventory.fishQuantity;
            

            arrowWay.target = arrowTargets[objectiveNumber];
            if(fish >= maxFish)
            {
                fish = maxFish;
                objectiveNumber = 1;
            }
            objectivesText[0].text = "- Fish (" + fish + "/" + maxFish + ")";
            
            objectivesText[0].color = Color.yellow;
            objectivesText[1].color = Color.gray;
            objectivesText[2].color = Color.gray;
        }
        if(objectiveNumber == 1)
        {
            
            sellFish = playerInventory.fishSell;
            arrowWay.target = arrowTargets[objectiveNumber];
                   
            if(sellFish >= maxSellFish)
            {
                sellFish = maxSellFish;
                objectiveNumber = 2;
            }
               
            objectivesText[1].text = "- SELL FISH (" + sellFish + "/" + maxSellFish + ")";
            
            objectivesText[0].color = Color.green;
            objectivesText[1].color = Color.yellow;
            objectivesText[2].color = Color.gray;
        }
        if(objectiveNumber == 2)
        {
            
            clothes = playerInventory.inventory.id.Count;
            arrowWay.target = arrowTargets[objectiveNumber];
            
            if(clothes >= maxClothes)
            {
                clothes = maxClothes;
                objectiveNumber = 3;
            }
            
            objectivesText[2].text = "- BUY CLOTHES (" + clothes + "/" + maxClothes + ")";
            
            objectivesText[0].color = Color.green;
            objectivesText[1].color = Color.green;
            objectivesText[2].color = Color.yellow;
        }
        if(objectiveNumber == 3)
        {
            objectivesText[0].fontStyle = FontStyles.Strikethrough;
            objectivesText[1].fontStyle = FontStyles.Strikethrough;
            objectivesText[2].fontStyle = FontStyles.Strikethrough;
            
            objectivesText[0].color = Color.gray;
            objectivesText[1].color = Color.gray;
            objectivesText[2].color = Color.gray;
            arrowWay.noObejectives = true;
        }
    }
}
