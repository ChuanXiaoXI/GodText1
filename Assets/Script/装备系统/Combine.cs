using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combine : MonoBehaviour
{
   public Inventory itemListE, itemListD, itemListC, itemListB, itemListA, itemListS, itemListSS, itemListSSS;
   public GameObject combine1,combine2,combine3;
   public GameObject equipment,itemPrefab,item;

   public void Combinetion()
   {
       if(combine1.transform.childCount != 0 && combine2.transform.childCount != 0 && combine3.transform.childCount != 0)
       {
           int combineNum;
           combineNum = Random.Range(0, 100);
           Destroy(combine1.transform.GetChild(0).gameObject);
           Destroy(combine2.transform.GetChild(0).gameObject);
           Destroy(combine3.transform.GetChild(0).gameObject);
           Instantiate(itemPrefab).transform.parent = equipment.transform;
           equipment.transform.GetChild(0).gameObject.transform.position = equipment.transform.position;
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 3)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 4)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 5)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListE.bagList[Random.Range(0, itemListE.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)]; 
               }

           }//ED级装备合成表


            if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 6)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
              if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 7)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 8)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListD.bagList[Random.Range(0, itemListD.bagList.Count)];
               }
              if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)]; 
               }

           }//DC装备合成表

           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 9)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 10)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 11)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListC.bagList[Random.Range(0, itemListC.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)]; 
               }

           }//CB装备合成表

           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 12)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 13)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 14)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListB.bagList[Random.Range(0, itemListB.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)]; 
               }

           }//AB装备合成表


           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 15)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 16)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 17)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListA.bagList[Random.Range(0, itemListA.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }

           }//AS装备合成表


           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 18)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 19)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 20)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListS.bagList[Random.Range(0, itemListS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
               

           }//S SS装备合成表

           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 21)
           {
               if(combineNum <= 25)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum > 25 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
               
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 22)
           {
               if(combineNum <= 50)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum > 50 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }
           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 23)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSS.bagList[Random.Range(0, itemListSS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }

           }
           if(combine1.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine2.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level + combine3.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item.level == 24)
           {
               if(combineNum <= 75)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum > 75 && combineNum <= 97)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum > 97 && 100 > combineNum)
               {
                equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)];
               }
               if(combineNum == 100)
               {
                  equipment.transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item = itemListSSS.bagList[Random.Range(0, itemListSSS.bagList.Count)]; 
               }

           }


            
       
           
           
       }
   }
  
}
