using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    private Transform sawlocation;
    [SerializeField] private Transform patrolpointalpha;
    [SerializeField] private Transform patrolpointbeta;

    [SerializeField] private float speed = 0f;

    [SerializeField] private bool goingright = false;

    // Start is called before the first frame update
    void Start()
    {
        sawlocation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0f)
        {
            Movement();

        }
    }

    private void Movement()
    {
        if(goingright == true)
        {
            //sawlocation.position = new Vector3(sawlocation.position.x + speed, sawlocation.position.y, sawlocation.position.z);
            sawlocation.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            //sawlocation.position = new Vector3(sawlocation.position.x - speed, sawlocation.position.y, sawlocation.position.z);
            sawlocation.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(sawlocation.position.x > patrolpointbeta.position.x)
        {
            goingright = false;
        }
        else if (sawlocation.position.x < patrolpointalpha.position.x)
        {
            goingright = true;
        }
    }
}
