using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{

    private int items = 0;
    List<GameObject> listofcoins = new List<GameObject>();


    [SerializeField] private Text itemText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ICollectible collectable = collision.GetComponent<ICollectible>();
        

        if (collision.gameObject.CompareTag("Collectable") && collision.gameObject.active == true)
        {
            //Destroy(collision.gameObject);
            items++;
            collision.gameObject.SetActive(false);
            listofcoins.Add(collision.gameObject);
            itemText.text = "Gold Collected: " + items;
            Debug.Log("Gold Collected: " + items);
        }

        //  Reset the Coins
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            foreach(GameObject gameobject in listofcoins)
            {
                gameobject.SetActive(true);
            }
            listofcoins.Clear();
        }
    }
}
