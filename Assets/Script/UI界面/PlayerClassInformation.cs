using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClassInformation : MonoBehaviour
{
    public Player_Class playerClass;
    public Image playerImage;
    public Text playerInformation;
    public Text playerStory;

    

    public void OnEnable()
    {
        playerImage.sprite = playerClass.playerImage;
        playerInformation.text = playerClass.playerInformation;
        playerStory.text = playerClass.playerStory;
    }
    
    
}
