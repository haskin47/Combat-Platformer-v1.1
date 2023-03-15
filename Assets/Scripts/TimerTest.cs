using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    [SerializeField] private float timeremaining = 120;
    bool isRunning = true;
    private void Update()
    {

        if (isRunning)
        {
            if (timeremaining > 0) timeremaining -= Time.deltaTime;
            int seconds = (int)timeremaining;
            //Debug.Log(seconds);

            if (timeremaining <= 0)
            {
                //  display message
                //Debug.Log("Game should pause now");
                isRunning = false;
            }
        }

    }
}
