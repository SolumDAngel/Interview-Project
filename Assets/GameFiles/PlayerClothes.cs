﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClothes : MonoBehaviour
{
    public Clothing.ClothesType type;
    public int clotheID;
    [HideInInspector]
    public ClothesSprites spritesData;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        spritesData = GameObject.FindObjectOfType<ClothesSprites>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    int oldID;
    void FixedUpdate()
    {
        if(oldID != clotheID)
        {
            oldID = clotheID;
            
            if(clotheID > -1 && clotheID < spritesData.sprites.Count)
                spriteRenderer.sprite = spritesData.sprites[clotheID];
            else
                spriteRenderer.sprite = null;
            
        }
    }
}
