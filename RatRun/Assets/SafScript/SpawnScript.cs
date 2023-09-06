using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawner;
    void Start()
    {
        var screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height * 1.2;
        float direction = Random.Range(0, 2) * 2 - 1;
        GameObject spawn = Instantiate(spawner, new Vector3(transform.position.x + ((float)screenWidth * direction), transform.position.y, 0), Quaternion.identity);
        spawner.GetComponent<spawnCar>().direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
