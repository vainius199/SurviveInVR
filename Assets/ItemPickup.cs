
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    ItemUse itemUse;
    
    public void Interact()
    {
        Debug.Log("Interecting with " + transform.name);
    }

    public void PickUP2()
    {
        //  ItemUse itemUse;
        //   itemUse.Use();
        // Debug.Log("SomeSHYYYYT");

      //  string testas = itemUse.Use();

      //  Debug.Log("My nigga " + testas);
    }


    public void PickUp()
    {

        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
             
    }

   


}
