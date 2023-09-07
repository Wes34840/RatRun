using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public int Points = 0;
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "score :" + Points);
    }

}
