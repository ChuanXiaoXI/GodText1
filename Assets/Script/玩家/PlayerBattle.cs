using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattle : MonoBehaviour
{
   [Header("战斗配置")]
   //public Image image;
   public TeamPlayer player;
   [Header("血条")]
   public Slider slider;
   public Slider speedSlider;

   public void Start()
   {
       //image.sprite = player.playerClass.playerImage;
   }
   public void Update()
   {
       slider.value = player.hp;
       slider.maxValue = player.totalhp;
       speedSlider.maxValue = (player.maxSpeed / player.speed) * 2;
       speedSlider.value = player.actionTime;

   }

}
