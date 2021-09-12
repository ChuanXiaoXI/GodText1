using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMission : MonoBehaviour
{
    public Mission mission;
    public int day;
    public string gameObjectName;//假设一个字符为gameObjectName。字符就是任何文字，字母
    public int enemyNum;
    public int enemyLevel;
   // public int enemyNumber;

    public int failDay;

    public float point;
    public float Cpoint;
    public float Spoint;
    public float SSSpoint;
    

    
   public Text missionInfo;//奖励信息信息
   public Text missionText;
  
   public GameObject timeManage;
   public GameObject player;
   public GameObject targetObject;
   public GameObject infromation;
   public List<GameObject> playerList = new List<GameObject>();
   public bool finish;
   public bool defeat;
   public int originalDay;

    public GameObject playerInformation;
    public GameObject enemyInformation;
    public GameObject itemInformation;
    public GameObject information;
    public GameObject informationManage;
    public Text itemInfo;


   public void OnEnable()
   {
    defeat = false;
    finish = false;
    //碰撞型任务
    player = GameObject.Find("Player");
    if(mission.gameObjectName != null)
    {
        gameObjectName = mission.gameObjectName;
        targetObject = GameObject.Find(gameObjectName);
    }
    //限制时间
    originalDay = timeManage.GetComponent<TimeManage>().day;
    //奖励
    point = mission.point;
    Cpoint = mission.Cpoint;
    Spoint = mission.Spoint;
    SSSpoint = mission.SSSpoint;
    
    informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    itemInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();
    


   }
   public void Update()
   {
       informationManage = GameObject.Find("InformationManage");
    information = informationManage.transform.GetChild(0).gameObject;
    enemyInformation = information.transform.GetChild(1).gameObject;
    playerInformation = information.transform.GetChild(0).gameObject;
    itemInformation = informationManage.transform.GetChild(1).gameObject;
    itemInfo = itemInformation.transform.GetChild(0).gameObject.GetComponent<Text>();
       SetMission();
       Finish();
       Defeat();
       if(mission.gameObjectName != null)
    {
        gameObjectName = mission.gameObjectName;
        targetObject = GameObject.Find(gameObjectName);
    }
     //限制时间
    originalDay = timeManage.GetComponent<TimeManage>().day;
    //奖励
    point = mission.point;
    Cpoint = mission.Cpoint;
    Spoint = mission.Spoint;
    SSSpoint = mission.SSSpoint;
   }
    public void SetMission()//update
    {
        if(mission == null)
        {
           gameObject.SetActive(false);
        }

        if(mission != null)
        {
            if(mission.day != 0)//生存型任务
            {
                day = mission.day;//生存时间
                missionText.text = mission.missionText.ToString();
                if(day == timeManage.GetComponent<TimeManage>().day)//生存时间达到world时间
                {
                    finish = true;//完成
                }
            }
            if(mission.gameObjectName != null)//碰撞型任务
            {
                 if(mission.failDay != 0)
                {
                failDay = mission.failDay + originalDay; 
                missionText.text = mission.missionText.ToString() +'\n' + "限期：第" + failDay + "天" + "00:00" + "前";
                }
                 if(mission.failDay == 0)
                 {
                      missionText.text = mission.missionText.ToString() +'\n' + "限期：第" + failDay + "天" + "00:00" + "前";
                 }

            }
            if(mission.enemyNum != 0)//击杀型任务
            {
                //enemyLevel = mission.enemyLevel;//击杀目标等级
                if(mission.failDay == 0)//无时间限制
                {
                missionText.text = mission.missionText.ToString() + "(" + enemyNum.ToString() + "/" + mission.enemyNum.ToString();
                if(enemyNum == mission.enemyNum)//击杀数达到任务数
                {
                    finish = true;
                }
                }
                if(mission.failDay != 0)
                {
                failDay = mission.failDay + originalDay;    
                missionText.text = mission.missionText.ToString() + "(" + enemyNum.ToString() + "/" + mission.enemyNum.ToString() + '\n' + "限期：第" + failDay + "天" + "00:00" + "前";
                if(enemyNum == mission.enemyNum)//击杀数达到任务数
                {
                    finish = true;
                }
                if(failDay == timeManage.GetComponent<TimeManage>().day)//期限到了,失败
                {
                    defeat = true;
                }
                }
            }
            
        }
    }
    public void OnMouseDown()//点击显示具体信息
    {
        information.SetActive(false);
   // playerInformation.SetActive(false);
    //enemyInformation.SetActive(false);
    itemInformation.SetActive(true);
    itemInfo.text = mission.missionInfo.ToString();
        
      
      
    }
    public void Finish()
    {
       if(finish == true)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].activeSelf == true)
                {
                    playerList[i].GetComponent<TeamPlayer>().point += point * 0.5f;
                    playerList[i].GetComponent<TeamPlayer>().Cpoint += Cpoint * 0.5f;
                    playerList[i].GetComponent<TeamPlayer>().Spoint += Spoint * 0.5f;
                    playerList[i].GetComponent<TeamPlayer>().SSSpoint += SSSpoint * 0.5f;
                }
                
            }
            
            mission = null;
        }
    }
    public void Defeat()
    {
         if(defeat == true)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].activeSelf == true)
                {
                    playerList[i].GetComponent<TeamPlayer>().point -= point;
                    playerList[i].GetComponent<TeamPlayer>().Cpoint -= Cpoint;
                    playerList[i].GetComponent<TeamPlayer>().Spoint -= Spoint;
                    playerList[i].GetComponent<TeamPlayer>().SSSpoint -= SSSpoint;
                }
            }
            mission = null;
        }
    }    
}
