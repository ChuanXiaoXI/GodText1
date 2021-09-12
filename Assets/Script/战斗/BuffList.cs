using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BuffList", menuName = "BuffList/New BuffList")]
public class BuffList : ScriptableObject
{
    public List<BuffAndDebuff> buffList = new List<BuffAndDebuff>();
   
}
