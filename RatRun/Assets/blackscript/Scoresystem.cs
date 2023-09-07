using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;



public class Scoresystem : MonoBehaviour
{
    private bool hasTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rat") && !hasTriggered)
        {
            GlobalData.playerPoints++;
            Destroy(gameObject);
        }
    }
}
