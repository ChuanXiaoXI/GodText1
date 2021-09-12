using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public int slotID;//空格ID = 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNumber;
    public GameObject itemInSlot;
    public GameObject child;
    

public void SetupSlot(Item item)
{
    
    if(item == null)
        {
        itemInSlot.SetActive(false);
        return;
        }
    slotImage.sprite = item.itemImage;
    slotNumber.text = item.itemHeld.ToString();
    slotItem = item;
    child = gameObject.transform.GetChild(0).gameObject;
    child.GetComponent<ItemOnDrag>().item = item;
    
}
}