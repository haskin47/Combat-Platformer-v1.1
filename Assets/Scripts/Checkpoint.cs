using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private Transform startLocation;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = startLocation.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Works");
        Vector3 s = startPosition;
        string position = $"X - {s.x} : Y - {s.y} : Z - {s.z}";
        Debug.Log(position);

        collision.gameObject.transform.position = startPosition;


        if (collision.gameObject.tag == "Player")
        {
            

        }
    }

}
