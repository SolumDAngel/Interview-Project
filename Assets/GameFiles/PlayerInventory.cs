using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int money;
    public int fishSell;
    public Inventory inventory;
    public PlayerClothes[] clothesPositions;
    
  
    public void EquipItem(Clothing.ClothesType type, int id)
    {
        if(id != -1) {
            if(inventory.clothType.Contains(type))
                if(inventory.id.Contains(id))
                {
                    for (int i = 0; i < clothesPositions.Length; i++) {
                        if(clothesPositions[i].type == type)
                        {
                            clothesPositions[i].clotheID = id;
                            return;
                        }
                    }
                }
                
        }
        else
        {
            if( inventory.clothType.Contains(type))
            {
                for (int i = 0; i < clothesPositions.Length; i++) {
                    if(clothesPositions[i].type == type)
                    {
                        clothesPositions[i].clotheID = id;
                        return;
                    }
                }
            }
        }
        print("You don't Have this Item !");
    }
    
    [System.Serializable]
    public struct Inventory
    {
        public List<Clothing.ClothesType> clothType;
        public List<int> id;
        
        public int fishQuantity;
    }
}
