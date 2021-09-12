using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buff : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public BuffAndDebuff buff;
    public Image buffImage;
    public int buffHeld;
    public GameObject buffInfo;
    public Text buffInfoText;
    void Start()
    {
        // gameObject.GetComponent<Image>().SetActive(false);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
{ 
        //buffInfo.GetComponent<PlayerClassInformation>().playerClass = playerClass;
        buffInfo.SetActive(true);
        
}
public void OnPointerExit(PointerEventData eventData)
{
        buffInfo.SetActive(false);
               
}
    // Update is called once per frame
    void Update()
    {
        /*if(buffHeld == 0)
        {
            Destroy(gameObject);
        }*/
      
    }
}
