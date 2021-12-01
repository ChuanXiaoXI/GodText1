using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCItem : MonoBehaviour
{
    public int getItemTime;
    public List<Inventory> npcDeathItem = new List<Inventory>();
     [Header("物品生成")]
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject itemPrefab;
    public GameObject itemMarkObject;
    [Header("命运")]
    public GameObject randomIndexManager;
    public int randomIndex1;
    public int randomIndex2;
    public int randomIndex3;
    public int randomIndexSum;
    public Text randomIndex1Text;
    public Text randomIndex2Text;
    public Text randomIndex3Text;
    public Text randomIndexSumText;
    [Header("命运算法（不必修改）")]
    public int upNumber1;
    public int upNumber2;
    public int upNumber3;
    public int downNumber1;
    public int downNumber2;
    public int downNumber3;
    public int startIndex;
    public int endIndex;
    public int point1;
    public int point2;
    public int point3;

    
    public void RandomIndex()//摇骰子
    {
        randomIndexManager.SetActive(true);
        randomIndex1 = Random.Range(1,7);
        randomIndex2 = Random.Range(1,7);
        randomIndex3 = Random.Range(1,7);
        randomIndexSum = (randomIndex1 + randomIndex2 + randomIndex3);
        randomIndex1Text.text = randomIndex1.ToString();
        randomIndex2Text.text = randomIndex2.ToString();
        randomIndex3Text.text = randomIndex3.ToString();
        randomIndexSumText.text = randomIndexSum.ToString();
    }
    public void Button()//按骰子总数生成装备
    {
        int randomNumber1 = Random.Range(1,101);
        int randomNumber2 = Random.Range(1,101);
        int randomNumber3 = Random.Range(1,101);
        if(randomIndexSum >= 3 && randomIndexSum <= 8)
        {
            upNumber1 = 95;
            upNumber2 = 40;
            upNumber3 = 10;
            downNumber1 = 50;
            downNumber2 = 4;
            downNumber3 = 1;
            startIndex = 3;
            endIndex = 8;   
            point1 = upNumber1 -((randomIndexSum - startIndex) * (upNumber1 - downNumber1)/(endIndex - startIndex));
            point2 = point1 + downNumber2 + ((randomIndexSum - startIndex) * (upNumber2 - downNumber2)/(endIndex - startIndex));
            point3 = 100;          
        }
        if(randomIndexSum >= 9 && randomIndexSum <= 13)
        {
            upNumber1 = 50;
            upNumber2 = 70;
            upNumber3 = 25;
            downNumber1 = 5;
            downNumber2 = 40;
            downNumber3 = 10;
            startIndex = 9;
            endIndex = 13;  
            point1 = upNumber1 - ((randomIndexSum - startIndex) * (upNumber1 - downNumber1)/(endIndex - startIndex));
            point2 = point1 + downNumber2 + ((randomIndexSum - startIndex) * (upNumber2 - downNumber2)/(endIndex - startIndex));
            point3 = 100;       
        }
        if(randomIndexSum >= 14 && randomIndexSum <= 18)
        {
            upNumber1 = 5;
            upNumber2 = 70;
            upNumber3 = 60;
            downNumber1 = 5;
            downNumber2 = 35;
            downNumber3 = 25;
            startIndex = 14;
            endIndex = 18;         
            point1 = upNumber1 - ((randomIndexSum - startIndex) * (upNumber1 - downNumber1)/(endIndex - startIndex));
            point2 = point1 + upNumber2 - ((randomIndexSum - startIndex) * (upNumber2 - downNumber2)/(endIndex - startIndex));
            point3 = 100;
        }

        if(randomNumber1 <= point1)//第一个格子
            {
                int random = Random.Range(0,npcDeathItem[0].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot1.transform;
                itemMarkObject.transform.position = slot1.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[0].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;


            }   
            if(randomNumber1 > point1 && randomNumber1 <= point2)
            {
                int random = Random.Range(0,npcDeathItem[1].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot1.transform;
                itemMarkObject.transform.position = slot1.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[1].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }   
            if(randomNumber1 > point2 && randomNumber1 <= point3)
            {
                int random = Random.Range(0,npcDeathItem[3].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot1.transform;
                itemMarkObject.transform.position = slot1.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[3].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }

            if(randomNumber2 <= point1)//第二个格子
            {
                int random = Random.Range(0,npcDeathItem[0].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot2.transform;
                itemMarkObject.transform.position = slot2.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[0].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;


            }   
            if(randomNumber2 > point1 && randomNumber2 <= point2)
            {
                int random = Random.Range(0,npcDeathItem[1].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot2.transform;
                itemMarkObject.transform.position = slot2.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[1].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }   
            if(randomNumber2 > point2 && randomNumber2 <= point3)
            {
                int random = Random.Range(0,npcDeathItem[3].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot2.transform;
                itemMarkObject.transform.position = slot2.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[3].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }

            if(randomNumber3 <= point1)//第三个格子
            {
                int random = Random.Range(0,npcDeathItem[0].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot3.transform;
                itemMarkObject.transform.position = slot3.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[0].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;


            }   
            if(randomNumber3 > point1 && randomNumber3 <= point2)
            {
                int random = Random.Range(0,npcDeathItem[1].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot3.transform;
                itemMarkObject.transform.position = slot3.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[1].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }   
            if(randomNumber3 > point2)
            {
                int random = Random.Range(0,npcDeathItem[3].bagList.Count);
                itemMarkObject = Instantiate(itemPrefab);
                itemMarkObject.transform.parent = slot3.transform;
                itemMarkObject.transform.position = slot3.transform.position;
                itemMarkObject.GetComponent<ItemOnDrag>().item = npcDeathItem[3].bagList[random];
                itemMarkObject.GetComponent<ItemOnDrag>().npcItem = true;

            }
           
           
            
        
    }






    
    
 
    // Start is called before the first frame update
   
}
