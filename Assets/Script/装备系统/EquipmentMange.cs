using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMange : MonoBehaviour
{
    static EquipmentMange instance;
    //public Player_Class playerClass;
    //public List<GameObject> players = new List<GameObject>();
    public List<GameObject> equipments = new List<GameObject>();
    
    void Awake()
    {
        if(instance != null)
          Destroy(this);
          instance = this;
    }
   private void Start() 
   {
     RefreshEquipment();
   }
   public void Update()
   {
     RefreshEquipment();
   }
    public static void RefreshEquipment()
    {
     
      
      for (int i = 0; i < 8; i++)
      {
         instance.equipments[i].GetComponent<GridManage>().refresh();
      }
      
      
    }
   
    
   
}
