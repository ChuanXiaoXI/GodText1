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
    //public RectTransform m_Rect;
    //public string dodgeString;
    //public float damageNumber;
    public float destroyTime;
    
    //public bool knock;
    

     public void Start()
    {
           teamPlayer = gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().player;
           //m_Rect = gameObject.GetComponent<RectTransform>();
           if(teamPlayer.dodgeString == null)
           {
               damageNumText.text = Convert.ToInt16(teamPlayer.damageNumber).ToString();
           }
           if(teamPlayer.dodgeString != null)
           {
               damageNumText.text = teamPlayer.dodgeString;
           }
            //damageNumText.text = Convert.ToInt16(damageNumber).ToString();
            
            teamPlayer.damageNumber = 0;
            teamPlayer.dodgeString = null;
        
        
        gameObject.transform.DOMove(new Vector3(  gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().damageNumobjectPoint2.transform.position.x,  gameObject.transform.parent.gameObject.GetComponent<PlayerBattle>().damageNumobjectPoint2.transform.position.y, 0f), 0.5f);
        //m_Rect.DOMove(new Vector3( m_Rect.localScale.x + 0.5f, gameObject.RectTransform.localScale.y + 0.5f, 0f), 0.5f);
        
        //destroyTime += Time.deltaTime;

        
        
    }
    void Update()
    {
       // damageNumText.text = Convert.ToInt16(damageNumber).ToString();
         //enemyUI = gameObject.transform.parent.gameObject;
         //gameObject.transform.
         destroyTime += Time.deltaTime;
         gameObject.transform.localScale = new Vector2((1.0f + (0.8f *destroyTime)), (1.0f + (0.8f *destroyTime)));
        //gameObject.transform.DOMove(new Vector3( gameObject.transform.localScale.x + 0.5f, gameObject.transform.localScale.y + 0.5f, 0f), 0.5f);
        if(destroyTime >= 0.5f)
        {

            Destroy(gameObject);
        }
    }

    
}
