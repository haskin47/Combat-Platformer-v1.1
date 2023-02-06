using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor_Zombie : MonoBehaviour
{
    private bool touching = false;
    public bool IsTouching() { return touching; }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain") 
        {
            touching = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }
}
