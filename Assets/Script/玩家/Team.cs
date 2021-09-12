using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New teamList", menuName = "teamList/New teamList")]
public class Team : ScriptableObject
{
    public List<Player_Class> teamList = new List<Player_Class>();
   
}
