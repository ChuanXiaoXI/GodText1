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
   [Header("战斗显示")]
   public GameObject damageNumobjectPoint1;//定位点
   public GameObject damageNumobjectPoint2;//定位点
    public GameObject buffInfoPoint1;
    public GameObject buffInfoPoint2;
    public GameObject skillNamePoint1;
    public GameObject skillNamePoint2;
   [Header("战斗动作")]
   public GameObject originalPosition;
   public GameObject actionPosition;
   public GameObject hurtPosition;

   

   public void Start()
   {
       //image.sprite = player.playerClass.playerImage;
   }
   public void Update()
   {
       slider.value = player.hp;
       slider.maxValue = player.totalhp;
       speedSlider.maxValue = 2;
       speedSlider.value = player.actionTime;

   }

}
