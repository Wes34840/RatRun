using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer sr;
    private PlayerMovement pm;
    private Collider2D coll;

    private float MovementSpeed;
    private int currentLane = 0;
    private bool isOnWater = true;
    private double drownTime = 0.1;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovement>();
        MovementSpeed = Camera.main.orthographicSize * 2 / 13;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "log")
        {
            
            isOnWater = false;
            drownTime = 0.1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "log")
        {
            
            isOnWater = true;
        }
    }
    private void Update()
    {
        MovementTick();

        if (currentLane >= 7 && currentLane <= 10)
        {
           
            DrownCheck();
        }
    }

    private void MovementTick()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + MovementSpeed);
            currentLane++;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + (MovementSpeed / 2), transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - MovementSpeed);
            currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - (MovementSpeed / 2), transform.position.y);
        }
    }

    private void DrownCheck()
    {
        if (isOnWater)
        {
            drownTime -= Time.deltaTime;
        }
        if (drownTime < 0)
        {
            gameObject.GetComponent<Hitbox>().Die("Drowning");
        }
    }
}
