using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
   public List<GameObject> npcList = new List<GameObject>();

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
}
