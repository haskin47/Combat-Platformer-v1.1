using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{

    private int items = 0;

    [SerializeField] private Text itemText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ICollectible collectable = collision.GetComponent<ICollectible>();


        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            items++;

            itemText.text = "Gold Collected: " + items;
        }
    }
}
