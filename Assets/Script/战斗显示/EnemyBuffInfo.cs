using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyBuffInfo : MonoBehaviour
{
    public GameObject enemyUI;
    public Text buffInfoText;
    public float destroyTime;
    public GameObject buffInfoPoint2;
    void Start()
    {
        //enemyUI = gameObject.transform.parent.gameObject;
      
        gameObject.transform.DOMove(new Vector3( buffInfoPoint2.transform.position.x,  buffInfoPoint2.transform.position.y, 0f), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
         destroyTime += Time.deltaTime;
         gameObject.transform.localScale = new Vector2((1.0f + (0.8f *destroyTime)), (1.0f + (0.8f *destroyTime)));
        if(destroyTime >= 0.5f)
        {

            Destroy(gameObject);
        }
    }
}
