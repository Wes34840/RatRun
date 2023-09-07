using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float dir;
    public float speed;
    [SerializeField] internal float minDelayTime;
    [SerializeField] internal float maxDelayTime;
    [SerializeField] internal float respawnTime;
    void Start()
    {
        player = GameObject.Find("Rat(Clone)");
        if (transform.position.x > player.transform.position.x)
        {
            dir = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            dir = 1;
        }
        speed = speed / 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (speed * dir), transform.position.y);
    }
}
