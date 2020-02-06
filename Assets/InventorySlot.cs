using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text text;

    Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;

        if (item != null)
        {
            icon.sprite = item.icon;
        
            icon.enabled = true;
        }
       
       
    }

    // TEST/////
    /*
    public void UpdateSlot(Item newItem)
    {
        item = newItem;                
        text.text = item.amount.ToString();
    }
    */

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
       
    }

    public void UseItem()
    {

        if(item != null)
        {
            item.Use();

           
        }
    }


}
