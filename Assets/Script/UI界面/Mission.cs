using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mission", menuName =  "Mission/New Mission")]//创造新的选项
public class Mission : ScriptableObject
{
    [Header("生存天数")]
    public int day;
    [Header("抵达目标")]
    public string gameObjectName;
    [Header("击杀怪物")]
    public int enemyNum;
    //public int enemyLevel;
    public string enemyObjectName;
    [Header("限时时间")]
    public int failDay;
    [Header("奖励")]
    public float point;
    public float Cpoint;
    public float Spoint;
    public float SSSpoint;
   
    //[Header("npc交互文本")]
    //public bool interaction;
    //public List<TextAsset> npcInteraction = new List<TextAsset>();
    //public List<GameObject> npcList = new List<GameObject>();
    //public List<Item> itemList = new List<Item>();
    [Header("任务信息")]
    [TextArea]
     public string missionInfo;//信息
     [TextArea]
     public string missionText;
     //public string missionTalk;
}
