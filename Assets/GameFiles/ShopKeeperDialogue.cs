using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopKeeperDialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button buttonBack,buttonNext;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextDialogue()
    {
        if(text.pageToDisplay == 15)
            buttonNext.gameObject.SetActive(false);
        else
            buttonNext.gameObject.SetActive(true);
        
        if(text.pageToDisplay < 15){
            text.pageToDisplay +=1;
            buttonBack.gameObject.SetActive(true);
        }
        else
            text.pageToDisplay = 15;
    }
    public void BackDialogue()
    {
        if(text.pageToDisplay == 1)
            buttonBack.gameObject.SetActive(false);
        else
            buttonBack.gameObject.SetActive(true);
        
        if(text.pageToDisplay >0){
            text.pageToDisplay -=1;
            buttonNext.gameObject.SetActive(true);
        }
        else
            text.pageToDisplay = 1;
    }
}
