using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float moveTime;
    public bool isMoving;
    public float movingTime;


    public Animator animator;
    Vector3 movement;
    public float InputX;
    public float InputY;
    public float stopX;
    public float stopY;

    public GameObject timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("World");
        //animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.gameObject.CompareTag("CenterPoint"))//碰撞检测
       {
          isMoving = false;
       }
    
    }

    // Update is called once per frame
    void Update()
    {
        if(!timeManager.GetComponent<TimeManage>().timeKnock)
        {
        InputY = Input.GetAxisRaw("Vertical");
        InputX = Input.GetAxisRaw("Horizontal");
        
        if (InputX > 0 && isMoving == false)
        {
            if(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject != null)
            {
                isMoving = true;
                gameObject.transform.DOMove(new Vector3(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject.transform.position.x, gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject.transform.position.y, 0f), moveTime);//移动                  
                gameObject.transform.parent = gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().rightGameObject.transform.GetChild(0).gameObject.transform;                               
            }
            
        }
         if (InputX < 0 && isMoving == false)
        {
            if(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject != null)
            {
                isMoving = true;
                gameObject.transform.DOMove(new Vector3(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject.transform.position.x, gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject.transform.position.y, 0f), moveTime);//移动
                gameObject.transform.parent = gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().leftGameObject.transform.GetChild(0).gameObject.transform;
                
            }
            
        }

 if (InputY > 0 && isMoving == false)
        {
            if(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject != null)
            {
                isMoving = true;
                gameObject.transform.DOMove(new Vector3(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject.transform.position.x, gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject.transform.position.y, 0f), moveTime);//移动
                gameObject.transform.parent = gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().upGameObject.transform.GetChild(0).gameObject.transform;
                
            }
            
        }

 if (InputY < 0 && isMoving == false)
        {
            if(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject != null)
            {
                isMoving = true;
                gameObject.transform.DOMove(new Vector3(gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject.transform.position.x, gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject.transform.position.y, 0f), moveTime);//移动
                gameObject.transform.parent = gameObject.transform.parent.parent.gameObject.GetComponent<BuildingGrid>().downGameObject.transform.GetChild(0).gameObject.transform;
                
            }
            
        }


       /* movement = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);
        InputY = Input.GetAxisRaw("Vertical");
        InputX = Input.GetAxisRaw("Horizontal");
        if (movement != Vector3.zero)
        {
        transform.Translate(movement);//移动
        animator.SetBool("isMoving", true);
        stopX = InputX;
        stopY = InputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);*/
        

        /*if (movement != Vector3.zero)//动画
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }*/

        /*if (movement.x > 0)//翻脸
            transform.localScale = new Vector3(1, 1, 1);
        if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);*/
        }
    }
}
