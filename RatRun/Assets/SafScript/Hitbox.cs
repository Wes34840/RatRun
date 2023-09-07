using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D hitbox;
    SpriteRenderer sr;
    [SerializeField] private Sprite[] deathSprites;
    internal PlayerMovement pm;
    void Start()
    {
        hitbox= GetComponent<BoxCollider2D>();
        sr= GetComponent<SpriteRenderer>();
        pm= GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Die("Roadkill");
        }
    }
    internal void Die(string type)
    {
        switch (type)
        {
            case "Drowning":
                sr.sprite = deathSprites[0];
                break;
            case "Roadkill":
                sr.sprite = deathSprites[1];
                break;
        }
        pm.enabled = false;
    }
}
