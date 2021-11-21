using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPoint : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("BuildingGrid"))//碰撞检测
       {
          transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject = other.gameObject;
       }
    
    }
}
