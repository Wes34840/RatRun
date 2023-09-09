using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width / 4 * 3, FullScreenMode.MaximizedWindow);
    }
}
