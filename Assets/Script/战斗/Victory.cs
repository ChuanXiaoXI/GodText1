using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
  public BattleManage battleManage;
  public List<Text> playerDamage = new List<Text>();
  public List<GameObject> playerDamageNum = new List<GameObject>();
  public List<TeamPlayer> player  = new List<TeamPlayer>();
  public Inventory itemListE, itemListD, itemListC, itemListB, itemListA, itemListS, itemListSS, itemListSSS;

  public int enemyPoint;

  
  public GameObject item1,item2,item3,itemPrefab;

  public void OnEnable()
  {
      enemyPoint = battleManage.enemyPoint;
      /*for (int i = 0; i < battleManage.remainPlayerList.Count ; i++)
            {
               for(int j = 0; j < battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList.Count ; j++)
               {
                   if(battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[j].overSkill)
                   {
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseAd += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].ad;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseAp += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].ap;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseTotalhp += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].totalhp;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseSpeed += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].speed;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseDef += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].def;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseMdef += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].mdef;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseCritDamge += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].critDamge;
                        battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.baseIq += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].iq;
                        battleManage. remainPlayerList[i].GetComponent<PlayerBattle>().player.baseCharm += battleManage.remainPlayerList[i].GetComponent<PlayerBattle>().player.skillList[i].charm;
                   }
               }
            }

      for (int i = 0; i < player.Count; i++)
      {
          if(player[i].playerClass == null)
          {
             playerDamageNum[i].SetActive(false);
          }
          if(player[i].playerClass != null)
          {
              playerDamage[i].text = player[i].name.ToString() + ":" + player[i].damageNum.ToString();
          }
      }*/

      Instantiate(itemPrefab).transform.parent = item1.transform;
      item1.transform.GetChild(0).gameObject.transform.position = item1.transform.position;
      Instantiate(itemPrefab).transform.parent = item2.transform;
      item2.transform.GetChild(0).gameObject.transform.position = item2.transform.position;
      Instantiate(itemPrefab).transform.parent = item3.transform;
      item3.transform.GetChild(0).gameObject.transform.position = item3.transform.position;

      if(enemyPoint == 1)
      {
          item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
          item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
          item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
      }
      if(enemyPoint == 2)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
          
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
          }
      }
      if(enemyPoint == 3)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
          }
      }
      if(enemyPoint == 4)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
          }
      }
      if(enemyPoint == 5)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
          }
      }
      if(enemyPoint == 6)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
          }
      }
      if(enemyPoint == 8)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
          }
      }
      if(enemyPoint == 9)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
          }
      }
      if(enemyPoint == 10)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
          }
      }
      if(enemyPoint == 12)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
          }
      }
      if(enemyPoint == 15)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
          }
      }
      if(enemyPoint == 16)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
          }
      }
      if(enemyPoint == 20)
      {
          int itemNum;
          itemNum = Random.Range(0, 100);
          if(itemNum <= 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
          }
          if(itemNum > 25)
          {
            item1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
            item3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
          }
      }







      
  }
}
