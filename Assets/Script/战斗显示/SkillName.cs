using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillName : MonoBehaviour
{
    
    public Text skillNameText;
    public float destroyTime;
    public GameObject skillNamePoint2;
    void Start()
    {
        gameObject.transform.DOMove(new Vector3( skillNamePoint2.transform.position.x,  skillNamePoint2.transform.position.y, 0f), 0.5f);
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
