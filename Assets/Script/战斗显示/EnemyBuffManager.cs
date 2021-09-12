using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffManager : MonoBehaviour
{
    public List<BuffAndDebuff> buffList = new List<BuffAndDebuff>();
    //public EnemyUI enemyUI;
    //public List<GameObject> buffObjectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* for(int i = 0; i < buffList.Count; i++)
        {
            buffList[i] = null;
        }
        for(int i = 0; i < enemyUI.buffAndDebuffList.Count; i++)
        {
            if(enemyUI.buffAndDebuffList[i] != null)
            {
                if(!buffList.Contains(enemyUI.buffAndDebuffList[i]))
                {
                    for(int j = 0; j < buffList.Count; j++)
                    {
                        if(buffList[j] == null)
                        {
                        buffList[j] = enemyUI.buffAndDebuffList[i];
                        
                        }
                    }
                }
            }
        }//增加
        for(int i = 0; i < buffList.Count; i++)
        {
            if(!enemyUI.buffAndDebuffList.Contains(buffList[i]))
            {
                buffList[i] = null;
            }

        }//移除

        for(int i = 0; i < buffObjectList.Count; i++)
        {
            
            buffObjectList[i].GetComponent<Buff>().buff = buffList[i];
            
                for(int k = 0; k < enemyUI.buffAndDebuffList.Count; k++)
                {
                    int buffConut = 0;
                    if(buffObjectList[i].GetComponent<Buff>().buff == enemyUI.buffAndDebuffList[k])
                    {
                        buffConut += 1;
                        buffObjectList[i].GetComponent<Buff>().buffHeld.text = buffConut.ToString();
                    }
                }
            
            //buffObjectList[i].GetComponent<Buff>().buffHeld.text = buffList.getCount(buffList[i]).ToString();
            //if(buff[i])
        }
        
       */

        
    }
}
