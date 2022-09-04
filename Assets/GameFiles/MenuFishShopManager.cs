using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuFishShopManager : MonoBehaviour
{



    public PlayerInventory player;
   
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI moneyText;
    
    public GameObject menu;
    public Interect interactArea;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerInventory>();
    }
    public void FixedUpdate()
    {
        if(interactArea.interacted)
            menu.SetActive(true);
        else
            menu.SetActive(false);
        
        fishText.text = "Fish : " + player.inventory.fishQuantity;
        moneyText.text = "$" + player.money;
    }

    public void SellFish()
    {
        if(player.inventory.fishQuantity > 0)
        {
            player.inventory.fishQuantity -= 1;
            player.money += 1;
            player.fishSell +=1;
        }
        else
            player.inventory.fishQuantity = 0;
        
    }
    
    public void Exit()
    {
        interactArea.interacted = false;
        menu.SetActive(false); 
    }
}
