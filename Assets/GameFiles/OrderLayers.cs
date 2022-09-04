using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrderLayers : MonoBehaviour
{
    
    public SpriteRenderer[] sprites;
    public List<SpriteRenderer> excludeSprites;
    // Start is called before the first frame update
    void Start()
    {
        sprites = GameObject.FindObjectsOfType<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++) {
            if(!excludeSprites.Contains(sprites[i]))
                sprites[i].sortingOrder = (int)(sprites[i].transform.position.y * -100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
