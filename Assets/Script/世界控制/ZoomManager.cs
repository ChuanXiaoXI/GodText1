using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    public List<GameObject> zoomList = new List<GameObject>();
    public List<GameObject> pointList = new List<GameObject>();
    public GameObject pointManager;
    // Start is called before the first frame update
    void OnEnable()
    {
        zoomList.Clear();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            zoomList.Add(gameObject.transform.GetChild(i).gameObject);
        }
        pointList.Clear();
        for (int i = 0; i < pointManager.transform.childCount; i++)
        {
            pointList.Add(pointManager.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < zoomList.Count; i++)
        {
            int randomIndex = Random.Range(0,pointList.Count);
            zoomList[i].transform.position = pointList[randomIndex].transform.position;
            pointList.Remove(pointList[randomIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
