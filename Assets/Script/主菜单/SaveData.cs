using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu(fileName = "New SaveData", menuName = "SaveData/New SaveData")]//创造新的选项
public class SaveData : ScriptableObject
{     
      public Player_Class playerClass;
      public List<int> equipmentIndexList = new List<int>();

    public float growthAd;
    public float growthAp; 
    public float growthTotalhp; 
    public float growthSpeed; 
    public float growthDef; 
    public float growthMdef; 
    public float growthCritDamge; 
    public float growthIq;
    public float growthCharm; 

    public float point;
    public float Cpoint;
    public float Spoint;
    public float SSSpoint;

    public List<Item> equipmentList = new List<Item>();
    public int bloodNum;
}
