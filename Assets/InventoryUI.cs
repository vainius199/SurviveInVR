﻿
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryTrigger;
  

    public GameObject InvenotoryUI;
    public GameObject OptionsUI;
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

   


    void UpdateUI()
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            if(i< inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }

        }
    }


    public void ChangeToOptionsUI()
    {
        InvenotoryUI.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void ChangeToInvtoryUI()
    {
        InvenotoryUI.SetActive(true);
        OptionsUI.SetActive(false);
    }

    public void ExitInvtoryUI()
    {
        InventoryTrigger.SetActive(true);
        gameObject.SetActive(false);
}

}
