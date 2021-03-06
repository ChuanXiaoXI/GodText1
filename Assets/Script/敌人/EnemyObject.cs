using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyObject : MonoBehaviour
{
    [Header("怪物列表")]
    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> npcList = new List<GameObject>();
    [Header("战斗管理配置")]
    public GameObject battleManage;
    [Header("怪物Object信息配置")]
    public GameObject itemInformation;
    public Text enemyInfo;
    public TeamManage teamManage;
    public float[] playerIq;
    public float[] enemyIq;
    public GameObject informationManage;
    public GameObject information;
    public GameObject playerInformation;
    public GameObject enemyInformation;
    //public GameObject itemInformation;
    public float playerMaxIq;
    public float enemyMaxIq;
    public int enemyNum1,enemyNum2,enemyNum3,enemyNum4,enemyNum5;
    public string name1,name2,name3;
   

    public bool battleKnock;
    public float KnockTime;

    public GameObject originalObject;
    public bool isMoving;
    public float moveTime;
    private void Start() 
    {
        originalObject = transform.parent.parent.gameObject;


        informationManage = GameObject.Find("InformationManage");
        information = informationManage.transform.GetChild(0).gameObject;
        enemyInformation = information.transform.GetChild(1).gameObject;
        playerInformation = information.transform.GetChild(0).gameObject;
        itemInformation = informationManage.transform.GetChild(1).gameObject;
        enemyInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();

        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;
        teamManage = GameObject.Find("Team").GetComponent<TeamManage>();
        
        enemyNum1 = enemyList.Count;
      
        enemyNum3 = enemyNum1 + 2;
        if(enemyNum3 > 20)
        {
            enemyNum3 = 20;
        }
    
        enemyNum5 = enemyNum1 - 2;
        if(enemyNum5 <= 1)
        {
            enemyNum5 = 1;
        }
        enemyNum2 = Random.Range(enemyNum5,enemyNum3);
        
       
    }
    private void Update()
    { 
        if(battleKnock == false)
        {
            KnockTime += Time.deltaTime;
            if(KnockTime >= 0.1f)
            {
                battleKnock = true;
                KnockTime = 0;
            }
        }

        if(!isMoving)
        {
            List<GameObject> moveObejctList = new List<GameObject>();
            if(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject != null)
            {
                moveObejctList.Add(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject);
            }
            if(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject != null)
            {
                moveObejctList.Add(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject);
            }
            if(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject != null)
            {
                moveObejctList.Add(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject);
            }
            if(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject != null)
            {
                moveObejctList.Add(transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject);
            }
            int index = Random.Range(0,moveObejctList.Count);
            gameObject.transform.DOMove(new Vector3(moveObejctList[index].transform.position.x, moveObejctList[index].transform.position.y, 0f), moveTime);//移动                  
            gameObject.transform.parent = moveObejctList[index].transform.GetChild(1).gameObject.transform; 
            isMoving = true;
           
        }




        for (int i = 0; i < enemyList.Count ; i++)
       {
           if(enemyList[i] != null)
           {
               name1 = enemyList[i].GetComponent<EnemyUI>().playerClass.playerName;
               break;
           }
       }

       for (int i = 0; i < enemyList.Count; i++)
       {
           if(enemyList[i] != null)
           {
              if(enemyList[i].GetComponent<EnemyUI>().playerClass.playerName != name1)
              {
                  name2 = enemyList[i].GetComponent<EnemyUI>().playerClass.playerName;
                  break;
              }
              if(enemyList[i].GetComponent<EnemyUI>().playerClass.playerName == name1)
              {
                  continue;
              }
           }
           
       }
        for (int i = 0; i < enemyList.Count; i++)
        {
            if(enemyList[i] != null)
            {
            if(enemyList[i].GetComponent<EnemyUI>().playerClass.playerName != name1 && enemyList[i].GetComponent<EnemyUI>().playerClass.playerName != name2)
            {
                name3 = enemyList[i].GetComponent<EnemyUI>().playerClass.playerName;
                break;
            }
            if(enemyList[i].GetComponent<EnemyUI>().playerClass.playerName == name1 || enemyList[i].GetComponent<EnemyUI>().playerClass.playerName == name2)
            {
                continue;
            }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("Player") && battleKnock)//碰撞检测
       {
        
          battleManage.GetComponent<BattleManage>().enemyList = enemyList;
          battleManage.GetComponent<BattleManage>().enemyObject = gameObject;
          //battleManage.GetComponent<BattleManage>().npcObject = npcList;
         // Destroy(gameObject);
          battleManage.SetActive(true);
           
       }
    
    }
     public void OnMouseDown()
  {
    information.SetActive(true);
    playerInformation.SetActive(false);
    enemyInformation.SetActive(false);
    itemInformation.SetActive(true);
    

      for (int i = 0; i < teamManage.players.Count; i++)
    {
        if(teamManage.players[i] != null)
        {
            playerIq[i] = teamManage.players[i].GetComponent<TeamPlayer>().iq;
        }
        if(teamManage.players[i] == null)
        {
            playerIq[i] = 0;
        }       
    }
    playerMaxIq = Mathf.Max(playerIq); 

    for (int i = 0; i < enemyList.Count; i++)
    {
        if(enemyList[i] != null)
        {
            enemyIq[i] = enemyList[i].GetComponent<EnemyUI>().iq;
        }
        if(enemyList[i] == null)
        {
            enemyIq[i] = 0;
        }       
    }
    enemyMaxIq = Mathf.Max(enemyIq); 
     if(playerMaxIq >= enemyMaxIq)
    {

    enemyInfo.text = "初步侦查，敌人数量大约：" + enemyNum2 + "\r\n" + "敌人种类可能为：" + "\r\n" + name1 + "\r\n" + name2 + "\r\n" + name3;

    }
    if(playerMaxIq < enemyMaxIq)
    {
        enemyInfo.text = "敌人存在强大个体，无法侦测，小心！！！";
    }

  }//鼠标单击显示信息
}
