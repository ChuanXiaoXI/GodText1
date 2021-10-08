using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorld : MonoBehaviour
{
    public GameObject timeManage;
    public GameObject battleManage;
    //public int worldIndex;
    public List<GameObject> E_LevelEnemyList = new List<GameObject>();
    public List<GameObject> C_LevelEnemyList = new List<GameObject>();
    public List<GameObject> S_LevelEnemyList = new List<GameObject>();
    public List<GameObject> SSS_LevelEnemyList = new List<GameObject>();
    public List<GameObject> enemyList = new List<GameObject>();
    public int dayNumber;//天数因子
    public int zoomNumber;
    public int worldNumber;
    public int enemyNumber;//

    // Start is called before the first frame update
    void OnEnable()
    {
        int index = Random.Range(1,3);
        worldNumber = timeManage.GetComponent<TimeManage>().level / 10;
        dayNumber = (timeManage.GetComponent<TimeManage>().day / 5) + index;
        enemyNumber = dayNumber + zoomNumber + worldNumber;     
        timeManage = GameObject.Find("World");
        battleManage = GameObject.Find("UI").transform.GetChild(6).gameObject;
    }
    public void EnemyList()
    {
        int index = Random.Range(1,100);
        int E_LevelIndex = (100 - ((23 * ((timeManage.GetComponent<TimeManage>().day) + (timeManage.GetComponent<TimeManage>().level))) / 10));
        int C_LevelIndex = (100 - ((11 * ((timeManage.GetComponent<TimeManage>().day) + (timeManage.GetComponent<TimeManage>().level))) / 10));
        int S_LevelIndex = (100 - ((3 * ((timeManage.GetComponent<TimeManage>().day) + (timeManage.GetComponent<TimeManage>().level))) / 10));
        if(E_LevelIndex <= 20)
        {
            E_LevelIndex = 20;
        }
        if(C_LevelIndex <= 60)
        {
            C_LevelIndex = 60;
        }
        if(S_LevelIndex <= 90);
        {
            S_LevelIndex = 90;
        }
        for(int i = 0; i < enemyNumber; i++)
        {
         if(index <= E_LevelIndex)
         {
            int randomIndex = Random.Range(0,E_LevelEnemyList.Count - 1);
            enemyList[i] = E_LevelEnemyList[randomIndex];
         }
         if(index >= (E_LevelIndex + 1) && index <= C_LevelIndex)
         {
             int randomIndex = Random.Range(0,C_LevelEnemyList.Count - 1);
             enemyList[i] = C_LevelEnemyList[randomIndex];
         }
         if(index >= (C_LevelIndex + 1) && index <= S_LevelIndex)
         {
             int randomIndex = Random.Range(0,S_LevelEnemyList.Count - 1);
             enemyList[i] = S_LevelEnemyList[randomIndex];
         }
          if(index >= (S_LevelIndex + 1) && index <= 100)
         {
             int randomIndex = Random.Range(0,SSS_LevelEnemyList.Count - 1);
             enemyList[i] = SSS_LevelEnemyList[randomIndex];
         }
        }
        battleManage.GetComponent<BattleManage>().enemyList = enemyList;
        battleManage.SetActive(true);

    }
}
