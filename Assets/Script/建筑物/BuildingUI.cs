using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    [Header("npc列表")]
    public List<Player_Class> npcList = new List<Player_Class>();
    public GameObject npcManager;
    [Header("‘拜访’按钮")]
    public GameObject firstManager;
    

    public void VisitButton()
    {
        firstManager.SetActive(false);
        npcManager.SetActive(true);
    }
}
