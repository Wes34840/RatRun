using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBuffer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Buffer());
    }

    private IEnumerator Buffer()
    {
        Time.timeScale = 10f;
        yield return new WaitForSeconds(10f);
        Time.timeScale = 1.0f;
        GetComponent<CanvasGroup>().alpha = 0f;

    }
}
