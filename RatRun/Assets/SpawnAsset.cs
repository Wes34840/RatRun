using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsset : MonoBehaviour
{
    internal float direction;
    internal LaneType type;
    public GameObject[] spawns;
    int chosen;
    float timer;
    void Start()
    {
        switch (type)
        {
            case LaneType.Water:
                chosen = 0;
                break;
            case LaneType.Road: 
                chosen = Random.Range(1, spawns.Length-1);
                break;

        }
        timer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        if (timer > 0)
        {
            timer = 4;
            Instantiate(spawns[chosen], transform);
        }
    }
}
