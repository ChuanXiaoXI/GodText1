using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMange : MonoBehaviour
{
    static InventoryMange instance;
    public Inventory mybag;
    public GameObject slotGrid;

    public GameObject emptySlot;
    //public Text itemInfromation;

    public List<GameObject> slots = new List<GameObject>();
    
    void Awake()
    {
        if(instance != null)
          Destroy(this);
          instance = this;
    }
    private void OnEnable() 
    {
        RefreshItem();
    }
    public void Update()
    {
        RefreshItem();
    }
    public static void RefreshItem()
    {
       /* for (int i = 0; i < 18; i++)
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
    
         for (int i = 0; i < instance.mybag.itemList.Count; i++)
       {
       
       
       instance.slots.Add(Instantiate(instance.emptySlot));
       instance.slots[i].transform.SetParent(instance.slotGrid.transform);
       instance.slots[i].GetComponent<Slot>().slotID = i;
       instance.slots[i].GetComponent<Slot>().SetupSlot(instance.mybag.itemList[i]);
       }*/
      for (int i = 0; i < 18; i++)
      {
          if(instance.slots[i].transform.childCount == 0)
          {
              instance.mybag.bagList[i] = null;
          }
          if(instance.slots[i].transform.childCount != 0)
          {
              instance.mybag.bagList[i] = instance.slots[i].transform.GetChild(0).gameObject.GetComponent<ItemOnDrag>().item;
          }
      }
       

    }
}

