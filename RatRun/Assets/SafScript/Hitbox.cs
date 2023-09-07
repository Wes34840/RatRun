using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D hitbox;
    SpriteRenderer sr;
    public Sprite newSprite;
    internal PlayerMovement pm;
    void Start()
    {
        hitbox= GetComponent<BoxCollider2D>();
        sr= GetComponent<SpriteRenderer>();
        pm= GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
   

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Car")
        {
            ChangeSprite(newSprite);
            pm.enabled= false;
        }
        
    }

    private void ChangeSprite(Sprite newSprite)
    {
        sr.sprite = newSprite;
    }
}
