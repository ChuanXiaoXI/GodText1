using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManage : MonoBehaviour
{
    static TeamManage instance;
    
    public List<GameObject> players = new List<GameObject>();
    public List<TeamPlayer> playerList = new List<TeamPlayer>();
    public PlayerData playerData;
    
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
    public static void RefreshPlayer()
    {
      for (int i = 0; i < 8; i++)
      {
         instance.players[i].GetComponent<TeamPlayer>().Equipment();
      }
      
    }
   
    
   
}