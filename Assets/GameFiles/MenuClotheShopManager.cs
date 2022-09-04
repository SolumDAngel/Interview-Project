using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MenuClotheShopManager : MonoBehaviour
{

    public int menuID;
    
    public GameObject menu;
    public GameObject[] itemsContainer;
    public GameObject dialogueBallon;
    
    public GameObject clothesShopUI;
    public TextMeshProUGUI returnButtonText, moneyText;

    public PlayerInventory player;

    public Interect interactArea;

    void FixedUpdate()
    {
       
        if(player == null)
            player = GameObject.FindObjectOfType<PlayerInventory>();
        else
            moneyText.text = "$"+player.money;
            
        if(interactArea.interacted)
            menu.SetActive(true);
        else
            menu.SetActive(false);
    }

    public void ChangeMenu(int id)
    {
        returnButtonText.text = "RETURN";
        exit = false;
        dialogueBallon.SetActive(false);
        
        for (int i = 0; i < itemsContainer.Length; i++) {
            
            if(i != id)
                itemsContainer[i].SetActive(false);
            else
                itemsContainer[i].SetActive(true);
            
        }
    }
    bool exit;

    
    public void Return()
    {
        returnButtonText.text = "EXIT";
        for (int i = 0; i < itemsContainer.Length; i++) {
            itemsContainer[i].SetActive(false);
        }
        dialogueBallon.SetActive(true);
   
        if(exit == false)
        {

         exit = true;
        }
        else
        {
         exit = false;
         Exit();
        }
    }
    
    public void Exit()
    {
        interactArea.interacted = false;
        clothesShopUI.SetActive(false); 
    }
}
