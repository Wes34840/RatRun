using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D hitbox;
    public AudioClip splat;
    public AudioClip splash;
    private AudioSource source;
    SpriteRenderer sr;
    [SerializeField] private Sprite[] deathSprites;
    internal PlayerMovement pm;
    void Start()
    {
        hitbox= GetComponent<BoxCollider2D>();
        sr= GetComponent<SpriteRenderer>();
        pm= GetComponent<PlayerMovement>();
        source= GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("hit by car");
            Die("Roadkill");
        }
    }
    internal void Die(string type)
    {
        switch (type)
        {
            case "Drowning":
                sr.sprite = deathSprites[0];
                source.PlayOneShot(splash, 1f);
                break;

            case "Roadkill":
                sr.sprite = deathSprites[1];
                source.PlayOneShot(splat, 1f);
                break;
        }
        pm.enabled = false;
    }
}
