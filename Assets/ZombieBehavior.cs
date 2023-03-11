using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxcollider;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {

            rigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)), transform.localScale.y);
    }

}
