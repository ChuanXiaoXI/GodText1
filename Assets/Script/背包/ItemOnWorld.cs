using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemOnWorld : MonoBehaviour
{
   public Item thisItem;
   // public GameObject itemObject;
   // public Inventory playerInventory;
   //public Text itemInfromation;
   //public GameObject infromation;
   public GameObject bag;
   public List<GameObject> bagList = new List<GameObject>();
   public GameObject itemPrefab;

    
    public GameObject playerInformation;
    public GameObject enemyInformation;
    public GameObject itemInformation;
    public GameObject information;
    public GameObject informationManage;
    public Text itemInfo;
   
  private void OnEnable()
  {
      //gameObject.transform.DOMove(new Vector3(0.14f, -1.0f, 0f), 1.0f);
    informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    itemInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();

      bag = GameObject.Find("myBag");
      for (int i = 0; i < bag.transform.childCount; i++)
      {
          bagList.Add(bag.transform.GetChild(i).gameObject);
      }
  }
  private void OnMouseDown()
  {
      information.SetActive(false);
   // playerInformation.SetActive(false);
    //enemyInformation.SetActive(false);
    itemInformation.SetActive(true);
    itemInfo.text = thisItem.itemInfo.ToString();
      /*GameObject gameObject8 = infromation.transform.GetChild(8).gameObject;
      List<GameObject> list = new List<GameObject>();
      
      for (int i = 0; i < 8; i++)
      {
          list.Add(infromation.transform.GetChild(i).gameObject);
          list[i].SetActive(false);
      }
     
      list.Clear();
      gameObject8.SetActive(true);
      itemInfromation = gameObject8.transform.GetChild(0).gameObject.GetComponent<Text>();

      itemInfromation.text = thisItem.itemInfo.ToString();*/

  }//鼠标单击显示信息
  
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("Player"))//碰撞检测
       {
           
           AddNewItem();
           Destroy(gameObject);
           
       }
    
    }
   
   public void AddNewItem()
   {
       if(thisItem.consumable)//判断是否为消耗品
       {
            for(int i = 0; i < bagList.Count; i++)
            {
                if(bagList[i].transform.childCount != 0)
                {
                    if(bagList[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item == thisItem)
                    {
                        bagList[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().itemHeld += 1;
                        return;
                    }
                    else
                    {
                        for(int j = 0; j < bagList.Count; j++)
                        {
                        if(bagList[j].transform.childCount == 0)
                        {
                            Instantiate(itemPrefab).transform.parent = bagList[j].transform;
                            bagList[j].transform.GetChild(0).gameObject.transform.position = bagList[j].transform.position;
                            bagList[j].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = thisItem;
                            return;
                        }
                        }

                    }
                }
            }
          
       } 
        else
        {
            for (int i = 0; i < bagList.Count; i++)
            {
               if(bagList[i].transform.childCount == 0)
               {
                   Instantiate(itemPrefab).transform.parent = bagList[i].transform;
                   bagList[i].transform.GetChild(0).gameObject.transform.position = bagList[i].transform.position;
                   bagList[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = thisItem;
                   break;
               }
            }
           
        } //非消耗品不叠加，直接进背包；
       // InventoryMange.RefreshItem();  //刷新背包
        
   }
}
