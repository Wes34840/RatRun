using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;



public class Scoresystem : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {


    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yes");
        if (other.name == "line");
        {
            other.GetComponent<points>().Points++;
            Destroy(gameObject);
        }
    }
}
