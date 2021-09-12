using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBattle : MonoBehaviour
{
    public List<Player_Class> enemyClass = new List<Player_Class>() ;
    
    public GameObject battleManage;
    public Text enemyInfo;

    
   // public EnemyUI playerscript;
    public TeamManage teamManage;
    public float[] playerIq;
    public float[] enemyIq;
    public GameObject infromation;
    
    public float playerMaxIq;
    public float enemyMaxIq;
   
   
    private void Start() 
    { 
       
        infromation = GameObject.Find("InformationManage");
        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;
        teamManage = GameObject.Find("Team").GetComponent<TeamManage>();
        

       
    }
   
    
   
     
}
