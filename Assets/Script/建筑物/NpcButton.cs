using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcButton : MonoBehaviour
{
    public Player_Class npcClass;
    public Text npcName;

    public void Start()
    {
        if(npcClass != null)
        {
            npcName.text = npcClass.playerName;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(npcClass == null)
        {
            gameObject.SetActive(false);
        }
       
        
    }
}
