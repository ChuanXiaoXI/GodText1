using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
   public GameObject timeManager;
    void Start()
    {
        timeManager = GameObject.Find("World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeaveButton()
    {
        timeManager.GetComponent<TimeManage>().timeKnock = false;
    }
}
