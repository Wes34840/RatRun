using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetHighScore : MonoBehaviour
{
    void Start()
    {
        if (GlobalData.playerPoints > GlobalData.highScore)
        {
            GlobalData.highScore = GlobalData.playerPoints;
        }
        if (GlobalData.highScore != 0)
        {
            GetComponent<TMP_Text>().text = GlobalData.highScore.ToString();
        }        
    }

}
