using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    [SerializeField]
    private GameObject[] itemList; // Stores the game items
    private int itemNum; // Selects a number to choose from the itemList
    private int randNum; // chooses a random number to see if loot os dropped- Loot chance
    private Transform EnemyPosition;
    private int NewRandom;
    

    public void DropItem()
    {
        StartCoroutine("Drop");
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(3f);
        NewRandom = Random.Range(0, 101);
        randNum = Random.Range(0, 101);
        if (NewRandom > 15)
        {

            if (randNum >= 67 && randNum < 99) // Star Tablet drop itemList[2] currently
            {
                itemNum = 2;// grabs the star tab
                Instantiate(itemList[itemNum], transform.position, Quaternion.identity);


            }
            else if (randNum >= 34 && randNum <= 66) // Extra life drop itemList[1] currently
            {

                itemNum = 1;// grabs the star tab
                Instantiate(itemList[itemNum], transform.position, Quaternion.identity);

            }
            else if (randNum >= 1 && randNum <= 33)// Health Heart drop itemList[0] currently
            {

                itemNum = 0;// grabs the star tab
                Instantiate(itemList[itemNum], transform.position, Quaternion.identity);

            }
        }
        Destroy(this);
    }

}
