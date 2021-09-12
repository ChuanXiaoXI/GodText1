using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameObject", menuName = "GameObject/New GameObject")]
public class GameObjectList : ScriptableObject
{
    public List<GameObject> gameObjectList = new List<GameObject>();
}
