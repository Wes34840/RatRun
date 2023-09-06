using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float dir;
    public float speed;
    void Start()
    {
        player = GameObject.Find("Rat");
        if(transform.position.x > player.transform.position.x)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * dir, transform.position.y);
    }
}
