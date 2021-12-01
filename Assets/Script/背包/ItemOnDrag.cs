using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler, IPointerExitHandler
{ 
    [Header("item属性传输")]
    public Item item;
    public string itemName;
    public Image itemImage;
    public GameObject colorObject;
    [Header("拖拽原坐标")]
    public Transform originalParent;//原父级
    public Vector3 originalPosition;//原坐标
    [Header("UI信息")]
    [TextArea]
    public string itemString;

    //public GameObject missionManager;
    public GameObject playerInformation;
    public GameObject enemyInformation;
    public GameObject itemInformation;
    public GameObject information;
    public GameObject informationManage;
    public Text itemInfo;

    public Text itemInfoText;
    public GameObject itemInfoTextObject;
    public GameObject itemInfoPoint1;
    //[消耗品]
    public int itemHeld;
    public Text itemNum;//数量
    public GameObject timeManage;
    [Header("战利品双击进入背包")]
    public float time;
    public GameObject bag;
    public GameObject itemPrefab;
    public bool trophy;
    [Header("战斗结束（无需更改）")]
    public GameObject battleManage;
    public GameObject victory;
    //[故事]
    public GameObject story;
    [Header("npc战利品")]
    public bool npcItem;


    [Header("装备属性")]
    public int gemPrepertyIndex;
    public bool isLoadItem;//读档锁

    public float replyHp;
    public float replyMp;
    public float replySp;

    public float replyHpPCT;
    public float replyMpPCT;
    public float replySpPCT;

    public float totalhp; 
    public float totalhpPCT;//血量与最大血量
    public float totalmp;  
    public float totalmpPCT;//魔量与最大魔量
    public float totalsp;  
    public float totalspPCT;//体力
    public float ad;  
    public float adPCT;//物攻
    public float ap;  
    public float apPCT;//法强
    public float def;  
    public float defPCT;//物防
    public float mdef;  
    public float mdefPCT;//魔防
    public float speed;  
    public float speedPCT;//速度
    public float dodge;  
  
    public float crit;  
  
    public float iq;  
    public float iqPCT;//脑力
    public float charm;  
    public float charmPCT;//魅力
    public float critDamge;  
   
    public float drainLife;  
   
    public float sword;//剑的系数
    public float gun;//枪的系数
    public int shieldFactor;//盾的系数
    public float skillOdds;//施法概率
    public bool charmSkillBool;//妖血机制
    public bool iqSkillBool;//悟道机制
    public bool apSkillBool;//圣魂机制
    public bool doubleDamage;

  private void Start()
  {
    itemHeld = item.itemHeld;

    time = Time.time;

    bag = GameObject.Find("bag");

    itemImage.sprite = item.itemImage;//图片传值

    //infromation = GameObject.Find("InformationManage");
    timeManage = GameObject.Find("World");

    story = GameObject.Find("UI").transform.GetChild(7).gameObject;
    
    itemInfoTextObject = GameObject.Find("UI").transform.GetChild(9).gameObject;
    informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    itemInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();

    colorObject.GetComponent<Image>().color = item.itemColor;
    
    IsLoadItem();
    ItemInformation();
    Preperty();
    
  }
  
  private void Update() 
  {
    itemNum.text = itemHeld.ToString();
    if(item.gemPrepertyList == null)
    {
      gemPrepertyIndex = 0;
    }
    Trophy();
    if(itemHeld == 0)
    {
      Destroy(gameObject);
    }  
  }
  public void IsLoadItem()
  {
    if(!isLoadItem)
    {
      if(item.gemPrepertyList != null)
      {
        gemPrepertyIndex = Random.Range(1,item.gemPrepertyList.randomPrepertyList.Count);
      }
    }

  }
  public void ItemInformation()
  {
    if(item.gemPrepertyList == null)
    {
      itemString = item.itemInfo;
    }
    if(item.gemPrepertyList != null)
    {
      itemString = item.itemInfo +  "\r\n"  +  "\r\n"  + item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].prepertyText +  "\r\n"  +  "\r\n"  + item.skillList[0].skillInfo;
    }

  }
  public void Preperty()
  {
    itemName = item.itemName;

    replyHp = item.replyHp;
    replyMp = item.replyMp;
    replySp = item.replySp;

    replyHpPCT = item.replyHpPCT;
    replyMpPCT = item.replyMpPCT;
    replySpPCT = item.replySpPCT;

    totalhp = item.totalhp;
    totalhpPCT = item.totalhpPCT;//血量与最大血量
    totalmp = item.totalmp;  
    totalmpPCT = item.totalmpPCT;//魔量与最大魔量
    totalsp = item.totalsp;  
    totalspPCT = item.totalspPCT;//体力
    ad = item.ad;  
    adPCT = item.adPCT;//物攻
    ap = item.ap;  
    apPCT = item.apPCT;//法强
    def = item.def;  
    defPCT = item.defPCT;//物防
    mdef = item.mdef;  
    mdefPCT = item.mdefPCT;//魔防
    speed = item.speed;  
    speedPCT = item.speedPCT;//速度
    dodge = item.dodge;  
  
    crit = item.crit; 
  
    iq = item.iq;  
    iqPCT = item.iqPCT;//脑力
    charm = item.charm;  
    charmPCT = item.charmPCT;//魅力
    critDamge = item.critDamge;  
   
    drainLife = item.drainLife;  
   
    sword = item.sword;//剑的系数
    gun = item.gun;//枪的系数
    shieldFactor = item.shieldFactor;//盾的系数
    skillOdds = item.skillOdds;//施法概率
    charmSkillBool = item.charmSkillBool;//妖血机制
    iqSkillBool = item.iqSkillBool;//悟道机制
    apSkillBool = item.apSkillBool;//圣魂机制
    doubleDamage = item.doubleDamage;

    if(item.gemPrepertyList != null)
    {
    replyHp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replyHp;
    replyMp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replyMp;
    replySp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replySp;

    replyHpPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replyHpPCT;
    replyMpPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replyMpPCT;
    replySpPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].replySpPCT;

    totalhp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalhp;
    totalhpPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalhpPCT;//血量与最大血量
    totalmp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalmp;  
    totalmpPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalmpPCT;//魔量与最大魔量
    totalsp += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalsp;  
    totalspPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].totalspPCT;//体力
    ad += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].ad;  
    adPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].adPCT;//物攻
    ap += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].ap;  
    apPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].apPCT;//法强
    def += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].def;  
    defPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].defPCT;//物防
    mdef += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].mdef;  
    mdefPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].mdefPCT;//魔防
    speed += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].speed;  
    speedPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].speedPCT;//速度
    dodge += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].dodge;  
  
    crit += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].crit; 
  
    iq += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].iq;  
    iqPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].iqPCT;//脑力
    charm += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].charm;  
    charmPCT += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].charmPCT;//魅力
    critDamge += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].critDamge;  
   
    drainLife += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].drainLife;  
   
    sword += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].sword;//剑的系数
    gun += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].gun;//枪的系数
    shieldFactor += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].shieldFactor;//盾的系数
    skillOdds += item.gemPrepertyList.randomPrepertyList[gemPrepertyIndex].skillOdds;//施法概率
    }


  }
  public void OnPointerEnter(PointerEventData eventData)//鼠标进入物体显示信息
{ 
        itemInfoText = itemInfoTextObject.GetComponent<Text>();
        itemInfoText.text = itemString;
        itemInfoTextObject.transform.position = itemInfoPoint1.transform.position;
        itemInfoTextObject.SetActive(true);
        
}
public void OnPointerExit(PointerEventData eventData)
{
       itemInfoTextObject.SetActive(false);
               
}
   public void OnMouseDown()
   {
    information.SetActive(false);
    //playerInformation.SetActive(false);
    //enemyInformation.SetActive(false);
    itemInformation.SetActive(true);
    itemInfo.text = item.itemInfo;
  
     
        if (Time.time - time <= 0.3f)//双击战利品进入背包
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
      if(item.story)//单击打开故事框
      {
        story.GetComponent<Story>().textFile = item.textFile;
        story.SetActive(true);
      }
        }
        time = Time.time;
    }
    public void Trophy()//战利品
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
          //Debug.Log(item.bloodClass);
          
          for (int i = 9; i < (eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().bloodNum + 9); i++)
          {
             if(eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] == null)//空血统
            {
              if(item.level == 2 && item.singleBlood == false)
              {
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].item = item;
              Destroy(gameObject);
              }
              if(item.singleBlood)
              {
              eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].item = item;
              Destroy(gameObject);
              }
            }
            if(eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i] != null)
            {
              if((item.level - eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].item.level) == 1 && item.bloodClass == eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].item.bloodClass)
              {
                eventData.pointerCurrentRaycast.gameObject.GetComponent<TeamPlayer>().equipmentList[i].item = item;
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
