using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float playermovementSpeed = 5f;

    SpriteRenderer spriteRd;
    Animator animatorContoller;

    Rigidbody2D rbbody;
    void Start()
    {
        rbbody = GetComponent<Rigidbody2D>();
        spriteRd = GetComponent<SpriteRenderer>();
        animatorContoller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");

        rbbody.velocity = new Vector2(movementX * playermovementSpeed, rbbody.velocity.y);

        if (Math.Abs(rbbody.velocity.x) > 0)
        {
            animatorContoller.SetInteger("switchAni", 1);
        }
        else
        {
            animatorContoller.SetInteger("switchAni", 0);
        }

        if (rbbody.velocity.x < 0)
        {
            spriteRd.flipX = true;
        }
        if (rbbody.velocity.x > 0)
        {
            spriteRd.flipX = false;
        }

    }
}
