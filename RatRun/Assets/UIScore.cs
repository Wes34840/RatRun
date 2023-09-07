using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{

    internal TMP_Text textfield;
    // Start is called before the first frame update
    void Start()
    {
        textfield = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textfield.text = $"Score : {GlobalData.playerPoints}";
    }
}
