using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManage : MonoBehaviour
{
    public TeamPlayer player;
    //public Player_Class playerClass;
    public List<GameObject> equipments = new List<GameObject>();
    public Text point1, point2, point3 ,point4;
    public Text name;
    
    
   public void OnEnable() 
   {
    //player = player.transform.GetChild(0).gameObject.GetComponent<TeamPlayer>();
   }
   public void Update()
   {
      refresh();
      Point();
   }
   public void refresh()
   {
        for (int i = 0; i < 9; i++)
        {
            if(equipments[i].transform.childCount != 0)
            {
               player.equipmentList[i] = equipments[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item;
            }
            if(equipments[i].transform.childCount == 0)
            {
               player.equipmentList[i] = null;
            }
            
            
        }
      
   }
   public void Point()
   {
      name.text = player.playerClass.playerName.ToString();
      point1.text = "点数:" + player.point.ToString();
      point2.text = "C级凭证:" + player.Cpoint.ToString();
      point3.text = "S级凭证:" + player.Spoint.ToString();
      point4.text = "SSS级凭证:" + player.SSSpoint.ToString();
   }
}