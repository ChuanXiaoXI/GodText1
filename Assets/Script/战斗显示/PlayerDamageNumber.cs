using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerDamageNumber : MonoBehaviour
{
    public TeamPlayer teamPlayer;
    public Text damageNumText;
    public float destroyTime;
    
    
    

     public void Start()
    {
           teamPlayer = gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().player;
           if(teamPlayer.dodgeString == null)
           {
                     if(teamPlayer.damageNum <= 0)
                    {
                      damageNumText.text = "1";
                    }
                    
                     if(teamPlayer.damageNum > 0)
                     {
                     damageNumText.text = Convert.ToInt16(teamPlayer.damageNumber).ToString();
                     }
           }
           if(teamPlayer.dodgeString != null)
           {
               damageNumText.text = teamPlayer.dodgeString;
           }
            
            
            teamPlayer.damageNumber = 1;
            teamPlayer.dodgeString = null;
        
        
        gameObject.transform.DOMove(new Vector3( gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().damageNumobjectPoint2.transform.position.x,  gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().damageNumobjectPoint2.transform.position.y, 0f), 0.5f);
       

        
        
    }
    void Update()
    {
      
         destroyTime += Time.deltaTime;
         gameObject.transform.localScale = new Vector2((1.0f + (0.8f *destroyTime)), (1.0f + (0.8f *destroyTime)));
        if(destroyTime >= 0.5f)
        {

            Destroy(gameObject);
        }
    }

    
}
