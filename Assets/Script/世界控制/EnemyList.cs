using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyList", menuName = "EnemyList/New EnemyList")]//创造新的选项
public class EnemyList : ScriptableObject
{
     public List<GameObject> enemyList = new List<GameObject>();

}

   