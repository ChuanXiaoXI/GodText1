using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [Header("npc数据传值")]
   public List<GameObject> npcList = new List<GameObject>();
    [Header("返回按钮")]
   public GameObject firstManager;

   public void Start()
   {
       for (int i = 0; i < transform.childCount; i++)
       {
           npcList.Add(transform.GetChild(i).gameObject);
       }
        for (int i = 0; i < transform.parent.gameObject.GetComponent<BuildingUI>().npcList.Count; i++)
       {
           npcList[i].GetComponent<NPC>().npc = transform.parent.gameObject.GetComponent<BuildingUI>().npcList[i];
           npcList[i].SetActive(true);
       }
   }
   public void ReturnButton()
   {

       firstManager.SetActive(true);
       gameObject.SetActive(false);

   }
}
