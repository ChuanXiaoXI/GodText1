using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<GameObject> missionList = new List<GameObject>();
    
    public void OnEnable()

    {
        missionList[0].SetActive(true);
        missionList[1].SetActive(false);
        missionList[2].SetActive(false);
        missionList[3].SetActive(false);
        missionList[4].SetActive(false);
        missionList[5].SetActive(false);


    }
}
