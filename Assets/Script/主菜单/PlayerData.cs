using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu(fileName = "New PlayerData", menuName = "SaveData/New PlayerData")]//创造新的选项
public class PlayerData : ScriptableObject
{     
      public List<SaveData> saveList = new List<SaveData>();
      public int worldIndex;
      public List<Item> bagList = new List<Item>();
      public List<int> equipmentIndexList = new List<int>();

}
