using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManage : MonoBehaviour
{
   //static TimeManage instance;

   public Text timeUI;
   public int time;
   public int day;
   public int level;
   public float a;
   public Text leverUI;
   public float timeFactor;

   public GameObject story;
   public GameObject battle;
   public GameObject diolog;

   public List<GameObject> playerList = new List<GameObject>();
    /*void Awake()
    {
        if(instance != null)
          Destroy(this);
          instance = this;
    }*/

    // Update is called once per frame
   public void Update()
    {
       TimeUI();
       TimeFactor();
       
    }
    public void TimeUI()
    {
         a += (Time.deltaTime * timeFactor);
        if(a >= 2.5f)
        {
            a = 0;
            time += 1;
            if(battle.activeSelf == false)
            {
                for(int i = 0; i < playerList.Count; i++)
                {
                    if(playerList[i].activeSelf == true)
                    {
                        playerList[i].GetComponent<TeamPlayer>().hp += (playerList[i].GetComponent<TeamPlayer>().replyHp / 6);
                        playerList[i].GetComponent<TeamPlayer>().mp += (playerList[i].GetComponent<TeamPlayer>().replyMp / 6);
                        playerList[i].GetComponent<TeamPlayer>().sp += (playerList[i].GetComponent<TeamPlayer>().replySp / 6);
                    }
                }
            }
        }
        if(time >= 24)
        {
            time = 0;
            day += 1;
        }
        timeUI.text = "第" + day.ToString() + "天" + time.ToString() + ":00";
        leverUI.text = "第" + level.ToString() + "轮回世界";
    }
    public void TimeFactor()
    {
        timeFactor = 1.0f;
        if(battle.activeSelf == true)
        {
            timeFactor = 0.2f;
        }
        if(diolog.activeSelf == true || story.activeSelf == true)
        {
            timeFactor = 0;
        }

    }

}
