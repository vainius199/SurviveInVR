using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    GameObject player;
    PlayerHealth playerHealth;


    GameObject myItems;
    ItemUse itemUse;

    
    public int scoreValue = 10;

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
  


    public virtual string Use()
    {

        if(name == "Healh")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeHealth(20);
            RemoveFromInventory();
        }

        if (name == "Shield")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.TakeArrmor(20);
            RemoveFromInventory();
        }

        if (name == "Gun")
        {
            

            myItems = GameObject.FindGameObjectWithTag("GameManager");
            itemUse = myItems.GetComponent<ItemUse>();

            itemUse.MainWeapon();
        }

        if (name == "WaterGun")
        {

           myItems = GameObject.FindGameObjectWithTag("GameManager");
            itemUse = myItems.GetComponent<ItemUse>();

            itemUse.WaterWeapon();
        }

        if (name == "BalloonGun")
        {

            myItems = GameObject.FindGameObjectWithTag("GameManager");
            itemUse = myItems.GetComponent<ItemUse>();

            itemUse.BallonWeapon();
        }


        if (name == "Box")
        {
            myItems = GameObject.FindGameObjectWithTag("GameManager");
            itemUse = myItems.GetComponent<ItemUse>();
            itemUse.GetPoints();

            GameManager.boxes += 1;
            RemoveFromInventory();
        }
                          

        Debug.Log("Using " + name);

        return name;
    }

    


    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}


