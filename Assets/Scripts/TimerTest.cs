using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Un

public class TimerTest : MonoBehaviour
{
    [SerializeField] private float timeremaining = 120;
    bool isRunning = true;
    
    [SerializeField] Text timer;

    [SerializeField] private GameObject timerGameObject;

    private void Start()
    {
        timer.text = timeremaining.ToString();
        timerGameObject.SetActive(false);
    }

    private void Update()
    {

        if (isRunning)
        {
            if (timeremaining > 0)
            {
                timeremaining -= Time.deltaTime;
            }
            int seconds = (int)timeremaining;
            timer.text = seconds.ToString();
            //Debug.Log(seconds);

            if (timeremaining <= 0)
            {
                //  display message
                Debug.Log("TIMES UP");
                isRunning = false;
                timerGameObject.SetActive(true);
            }
        }

    }
}
