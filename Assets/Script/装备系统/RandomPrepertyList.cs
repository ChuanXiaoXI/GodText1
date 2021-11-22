using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PropertyList", menuName = "Property/New PropertyList")]//创造新的选项

public class RandomPrepertyList: ScriptableObject
{
   
   public List<RandomPreperty> randomPrepertyList = new List<RandomPreperty>();
}
