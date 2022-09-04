using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

// [ExecuteAlways]
public class Clothing : MonoBehaviour
{
    
    /*
    
    Objective: Make the clothes buyable and equipable
    
    Alternatives: Instead put this script in every piece I can make a clothe manager that only receive button infos (id, type, moneyText)
    But I don't think this early :/
    
    Obs: I have used ExecuteAlways some times to set the products more fast. Some things in this code are made to use this same.
    
    */
    public enum ClothesType 
    {
        None, Dress,
        Glasses, Hat,
        Jacket, Pants,
        Shoe, Short,
        Skirt, Suit,
        TShirt
    }
    public ClothesType clothingType;
  
    public bool playerHaveThisItem;
  
    public int clothesID;
    [HideInInspector] public ClothesSprites clothesData;
   
    public SpriteRenderer sprite;
    public Image spriteImage;

    public Button button;
    
    public int moneyCost;
    
    // public GameObject moneyPrefab; - Used to speed Up the product Settings
    public TextMeshProUGUI moneyText;
  
    void Start()
    {
        clothesData = GameObject.FindObjectOfType<ClothesSprites>();
        sprite = GetComponent<SpriteRenderer>();
        spriteImage = GetComponent<Image>();
        button = GetComponent<Button>();
        
        if(button != null)
        {
            button.onClick.AddListener(delegate {SendInfoToManager(); });
        }
        
        /*
        // Used to speed Up the product Settings
          
        if(moneyText == null)
        {
        GameObject tmp = Instantiate(moneyPrefab);
    
        tmp.transform.localScale = new Vector3(0.0015f,0.0015f,0.0015f);
        tmp.transform.parent = transform;
        tmp.transform.localPosition = new Vector3(0,0,0);
        moneyText = tmp.GetComponent<TextMeshProUGUI>();
        }
        */
    }

    // always check the playerMoney and set on moneyText;
    void FixedUpdate()
    {
        if(!playerHaveThisItem)
            if(clothesData.player.money >= moneyCost)
                moneyText.color = Color.green;
            else
                moneyText.color = Color.red; 
        
    }

    // tmp variables
    int oldID;
    int oldMoneyCost;
    float tmpTime = 0.2f;
    bool itemEquipped;
    //
    void Update()
    {
        // Change the sprite in realtime
        // Used to speed Up the product Settings
        if(oldID != clothesID)
        {
            if(sprite != null)
                if(clothesID >= 0 && clothesID < clothesData.sprites.Count)
                    sprite.sprite = clothesData.sprites[clothesID];
        
            if(spriteImage != null)
                if(clothesID >= 0 && clothesID < clothesData.sprites.Count)
                {
                    spriteImage.sprite = clothesData.sprites[clothesID];
                    spriteImage.SetNativeSize();
                }
                
            oldID = clothesID;
        }    
        //
        //
        
        // Don't let the moneyCost go below Zero.
        // made to avoid error of negatives number in products setup
        if(playerHaveThisItem == false)
        {
            if(oldMoneyCost != moneyCost)
            {
                int tmpInt = Mathf.Abs(moneyCost);
                moneyCost = tmpInt;
                moneyText.text = "$" + moneyCost;
                oldMoneyCost = moneyCost;
            }
        }
        else
        {
            // is Just for aesthetics and info feed back for player
            //
            if(tmpTime > 0)
                tmpTime -= 1 * Time.deltaTime;
            else
            {
                if(itemEquipped == false)
                    for (int i = 0; i < clothesData.player.clothesPositions.Length; i++) {
                        if(clothesData.player.clothesPositions[i].type == clothingType)
                            if(clothesData.player.clothesPositions[i].clotheID != clothesID)
                            {
                                moneyText.text = "Equip";
                                moneyText.color = Color.yellow;
                            }
                    }
            }
            //
            //
        }
    }
    
    // After buy the item, he turn in equipable and add to player Inventory.
    //
    void SendInfoToManager()
    {
        if(playerHaveThisItem == false){
            if(clothesData.player.money >= moneyCost)
            {
                clothesData.player.money -= moneyCost;
                clothesData.player.inventory.clothType.Add(clothingType);
                clothesData.player.inventory.id.Add(clothesID);
                playerHaveThisItem = true;
                moneyText.text = "acquired";
                moneyText.color = Color.yellow;
               
                button.onClick.RemoveAllListeners();
              
                button.onClick.AddListener(delegate {EquipThisItem(); });
            }
        }
    
    }
    //
    //
    
    //tmp variable
    bool itemUnequip;
    // Check if the player have this Item in inventory and equip or Unequip the Item
    //
    public void EquipThisItem()
    {
        if(itemUnequip == false)
        {
            for (int i = 0; i < clothesData.player.clothesPositions.Length; i++) {
                if(clothesData.player.clothesPositions[i].type == clothingType)
                    if(clothesData.player.clothesPositions[i].clotheID != clothesID)
                    {
                        clothesData.player.EquipItem(clothingType,clothesID);
                        moneyText.text = "Equipped";
                        moneyText.color = Color.green;
                        itemUnequip = true;
                    }
            }
        }
        else
        {
       
            for (int i = 0; i < clothesData.player.clothesPositions.Length; i++) {
                if(clothesData.player.clothesPositions[i].type == clothingType)
                    if(clothesData.player.clothesPositions[i].clotheID == clothesID)
                    {
                        // -1 is for choose the null sprite
                        //
                        clothesData.player.EquipItem(clothingType,-1);
                        moneyText.text = "Equip";
                        moneyText.color = Color.yellow;
                        itemUnequip = false;
                    }

            }
        }
     
    }
}











