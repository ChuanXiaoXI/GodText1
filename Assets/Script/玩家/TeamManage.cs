using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class TeamManage : MonoBehaviour
{
    static TeamManage instance;
    
    public List<GameObject> players = new List<GameObject>();
    public List<TeamPlayer> playerList = new List<TeamPlayer>();
    public PlayerData playerData;
     [Header("行动力")]
    public float strength;
    public Text strengthText;
    public float socialStrength;
    public bool socialBool;
    public float battleStrength;
    public bool battleBool;
    public float searchStrength;
    public bool searchBool;
    
    
    void Awake()
    {
        if(instance != null)
          Destroy(this);
          instance = this;
    }
   private void Start() 
   {
     RefreshPlayer();
     
   }
   private void Update()
   {
     Strength();
   }
   public static void Strength()
   {
     instance.strengthText.text = "行动力：" + Convert.ToInt16(instance.strength).ToString();

   }
    public static void RefreshPlayer()
    {
      for (int i = 0; i < 8; i++)
      {
         instance.players[i].GetComponent<TeamPlayer>().Equipment();
      }
      
    }
   
    
   
}