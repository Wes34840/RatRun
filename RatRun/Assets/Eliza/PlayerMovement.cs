using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MovementSpeed;
    internal LaneType type;
    SpriteRenderer sr;
    public Sprite newSprite;
    private PlayerMovement pm;
    private void Start()
    {

       
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovement>();


        MovementSpeed = Camera.main.orthographicSize * 2 / 13;

    }


    private void OnCollisionStay2D(Collision2D target)
    {
        if (type == LaneType.Water && target.gameObject.tag != "Log" )
        { 
            pm.enabled= false;
            ChangeSprite(newSprite);
        }

    }
    
    private void ChangeSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + MovementSpeed);
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + (MovementSpeed / 2), transform.position.y);
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - MovementSpeed);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - (MovementSpeed / 2), transform.position.y);
        }
    }
}
