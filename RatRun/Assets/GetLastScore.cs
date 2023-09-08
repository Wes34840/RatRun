using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetLastScore : MonoBehaviour
{
    void Start()
    {
        if (GlobalData.playerPoints != 0)
        {
            GetComponent<TMP_Text>().text = GlobalData.playerPoints.ToString();
        }
    }

}
