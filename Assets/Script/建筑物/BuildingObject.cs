using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingObject : MonoBehaviour
{
    public GameObject buildingUI;
    public bool isTrigger;

    public GameObject timeManager;

    // Start is called before the first frame update

    public void Start()
    {
        timeManager = GameObject.Find("World");
    }
     private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("Player"))//碰撞检测
       {
           isTrigger = true;   
           timeManager.GetComponent<TimeManage>().timeKnock = true;
           buildingUI.SetActive(true);
       }
    
    }
      private void OnTriggerExit2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("Player"))//碰撞检测
       {
           isTrigger = false;
       }
    
    }
    /*public void OnMouseDown()
    { 
        if(isTrigger == true)
        {
            buildingUI.SetActive(true);
        }
    }*/

}
