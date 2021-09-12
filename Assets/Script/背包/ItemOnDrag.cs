using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{ 
    [Header("item属性传输")]
    public Item item;
    public Image itemImage;
    public GameObject colorObject;
    [Header("拖拽原坐标")]
    public Transform originalParent;//原父级
    public Vector3 originalPosition;//原坐标
    [Header("UI信息")]
    //public GameObject missionManager;
    public GameObject playerInformation;
    public GameObject enemyInformation;
    public GameObject itemInformation;
    public GameObject information;
    public GameObject informationManage;
    public Text itemInfo;
    //[消耗品]
    public int itemHeld;
    public Text itemNum;//数量
    public GameObject timeManage;
    //[双击进入背包]
    public float time;
    public GameObject bag;
    public GameObject itemPrefab;
    public bool trophy;
    //[结束战斗]
    public GameObject battleManage;
    public GameObject victory;
    //[故事]
    public GameObject story;

  private void Start()
  {
    time = Time.time;
    bag = GameObject.Find("bag");
    itemImage.sprite = item.itemImage;//图片传值
    //infromation = GameObject.Find("InformationManage");
    timeManage = GameObject.Find("World");
    story = GameObject.Find("UI").transform.GetChild(7).gameObject;
    
    informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    itemInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();

    colorObject.GetComponent<Image>().color = item.itemColor;
    itemHeld = item.itemHeld;
    
  }
  
  private void Update() 
  {
    itemNum.text = itemHeld.ToString();
    Trophy();
    if(itemHeld == 0)
    {
      Destroy(gameObject);
    }

    
  }
   public void OnMouseDown()
   {
    information.SetActive(false);
    //playerInformation.SetActive(false);
    //enemyInformation.SetActive(false);
    itemInformation.SetActive(true);
    itemInfo.text = item.itemInfo.ToString();
  
     
        if (Time.time - time <= 0.3f)
          {
            if(gameObject.transform.parent.gameObject.name == "Victory1" || gameObject.transform.parent.gameObject.name == "Victory2" || gameObject.transform.parent.gameObject.name == "Victory3")
             { 
                battleManage = GameObject.Find("Battle");
                victory = GameObject.Find("Victory");
               for (int i = 0; i < 18 ; i++)
               {
                   if(bag.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.childCount == 0)
                   {
                     Instantiate(itemPrefab).transform.parent = bag.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform;
                     bag.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.position = bag.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.position;
                     bag.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = gameObject.GetComponent<ItemOnDrag>().item;
                     for (int j = 0; j < battleManage.GetComponent<BattleManage>().remainPlayerList.Count; j++)
                     {
                         battleManage.GetComponent<BattleManage>().remainPlayerList[j].GetComponent<PlayerBattle>().player.damageNum = 0;
                         Destroy(battleManage.GetComponent<BattleManage>().remainPlayerList[j]);
                     }
                     battleManage.GetComponent<BattleManage>().remainPlayerList.Clear();
                     Destroy(victory.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
                     Destroy(victory.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject);
                     Destroy(victory.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject);
                     victory.SetActive(false);
                     battleManage.SetActive(false);


                     break;
                   }
               }
             }
             if(item.story)
      {
        story.GetComponent<Story>().textFile = item.textFile;
        story.SetActive(true);
      }
        }
        time = Time.time;
    }
    public void Trophy()
    {
      trophy = false;
      if(gameObject.transform.parent.gameObject.name == "Victory1" || gameObject.transform.parent.gameObject.name == "Victory2" || gameObject.transform.parent.gameObject.name == "Victory3")
      {
        trophy = true;
      }
    }

    
  public void OnBeginDrag(PointerEventData eventData)
  { 
    
    if(trophy == false)
    {
    originalPosition = transform.position;
    originalParent = transform.parent;
    transform.SetParent(transform.parent.parent);
    transform.position = eventData.position;
    GetComponent<CanvasGroup>().blocksRaycasts = false;//射线关闭
    }
    
  
  }
    
    
  
   public void OnDrag(PointerEventData eventData)
  {
    if(trophy == false)
    {
     transform.position = eventData.position;
     Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }
    
  }

     
     
  
  public void OnEndDrag(PointerEventData eventData)
  {
    if(trophy == false)
    {

    
     if(eventData.pointerCurrentRaycast.gameObject == null)
     {
       transform.position = originalPosition;
       transform.parent = originalParent;
       GetComponent<CanvasGroup>().blocksRaycasts = true;

     }
    
      if(item.equipment == true)//装备,落地对象：背包空格，空格装备栏，装备
      {
        if(eventData.pointerCurrentRaycast.gameObject.name == "Slot" || eventData.pointerCurrentRaycast.gameObject.name == item.equipmentClass)//空格子，空装备
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);//父级设置
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;//坐标
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线恢复
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
            TeamManage.RefreshPlayer();//刷新属性
            
            
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "Item")//需要更新为Item（Clone）
        {
            if(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == "Slot" || eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == item.equipmentClass)//换装，换格子
            {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;

            eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
            TeamManage.RefreshPlayer();//刷新属性
           
            
            }
            else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             TeamManage.RefreshPlayer();//刷新属性
            }
            
        }
        else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             TeamManage.RefreshPlayer();//刷新属性
           

            }
        
      }
      if(item.consumable == true)//消耗品，落地对象：空格子，换格子，以及玩家图标
      {
        if(eventData.pointerCurrentRaycast.gameObject.name == "Slot" && eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name != "Combine")//空格子
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);//父级设置
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;//坐标
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线恢复
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "Item" && eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.gameObject.name != "Combine")//需要更新为Item（Clone）
        {
            if(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == "Slot")//换格子
            {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;

            eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
            }
             else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             
            }
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "PlayerHead")
        {
          transform.position = originalPosition;
          transform.parent = originalParent;
          GetComponent<CanvasGroup>().blocksRaycasts = true;
          itemHeld -= 1;
          if(itemHeld == 0)
          {  
          Destroy(gameObject);
          }
          for (int i = 0; i < 100; i++)
          {
            if(eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().consumableList[i] == null)
            {
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().consumableList[i] = item;
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().consumableTimeList[i] = timeManage.GetComponent<TimeManage>().time;
              break;
            }
          }
          
          

        }
        else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             
            }
      }
     if(item.blood == true)
     {
       if(eventData.pointerCurrentRaycast.gameObject.name == "Slot")//空格子
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);//父级设置
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;//坐标
            GetComponent<CanvasGroup>().blocksRaycasts = true;//射线恢复
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "Item")//需要更新为Item（Clone）
        {
            if(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == "Slot")//换格子
            {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;

            eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryMange.RefreshItem();//刷新背包
            EquipmentMange.RefreshEquipment();//刷新装备
            }
             else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             
            }
        }
        if(eventData.pointerCurrentRaycast.gameObject.name == "PlayerHead")
        {
          
          transform.position = originalPosition;
          transform.parent = originalParent;
          GetComponent<CanvasGroup>().blocksRaycasts = true;
          
          
          for (int i = 9; i < (eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().bloodNum + 9); i++)
          {

             if(eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] == null)//空血统
            {
              if(item.level == 2 && item.singleBlood == false)
              {
                
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] = item;
              Destroy(gameObject);
              }
              if(item.singleBlood)
              {
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] = item;
              Destroy(gameObject);
              }
            }
            if(eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] != null)
            {
              if((item.level - eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].level) == 2 && item.bloodClass == eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().playerClass.equipmentList[i].bloodClass)
              {
                eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] = item;
                Destroy(gameObject);
              }
            }
          }

        }
        else
            {
             transform.position = originalPosition;
             transform.parent = originalParent;
             GetComponent<CanvasGroup>().blocksRaycasts = true;
             InventoryMange.RefreshItem();//刷新背包
             EquipmentMange.RefreshEquipment();//刷新装备
             
            }

     }
    }    
    
  }
}
