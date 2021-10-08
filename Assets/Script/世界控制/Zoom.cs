using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
   public GameObject buildingManager;
   public List<GameObject> buildingList = new List<GameObject>();
   public GameObject pointManager;
   public List<GameObject> pointList = new List<GameObject>();

   
 
  public void OnEnable()
  {
    buildingList.Clear();
     for (int i = 0; i < buildingManager.transform.childCount; i++)
    {
           buildingList.Add(buildingManager.transform.GetChild(i).gameObject);
    }
    pointList.Clear();
     for (int i = 0; i < pointManager.transform.childCount; i++)
    {
           pointList.Add(pointManager.transform.GetChild(i).gameObject);
    }
    for(int i = 0; i < buildingManager.transform.childCount; i++)
    {
            int randomIndex = Random.Range(0,pointList.Count);
            buildingList[i].transform.position = pointList[randomIndex].transform.position;
            
            pointList.Remove(pointList[randomIndex]);
    }
  }
}
