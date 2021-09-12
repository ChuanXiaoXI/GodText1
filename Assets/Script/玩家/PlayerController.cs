using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Animator animator;
    Vector3 movement;
    public float InputX;
    public float InputY;
    public float stopX;
    public float stopY;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);
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
        animator.SetFloat("InputY", stopY);
        

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
