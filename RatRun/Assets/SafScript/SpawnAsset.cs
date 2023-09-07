using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsset : MonoBehaviour
{
    internal LaneType type;
    public GameObject[] spawns;
    int chosen;
    float timer, timerDelay;
    private assetMove assetScript;
    void Start()
    {
        switch (type)
        {
            case LaneType.Water:
                chosen = 0;
                break;
            case LaneType.Road:
                chosen = Random.Range(1, spawns.Length);
                break;

        }
        assetScript = spawns[chosen].GetComponent<assetMove>();
        timerDelay = Random.Range(assetScript.minDelayTime * 10, assetScript.maxDelayTime * 10)/10;
        timer = timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = assetScript.respawnTime;
            Instantiate(spawns[chosen], transform.position, Quaternion.identity);
        }
    }
}
