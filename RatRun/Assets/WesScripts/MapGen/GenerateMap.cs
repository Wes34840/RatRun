using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Sprite laneSprites;
    [SerializeField] private GameObject lanePrefab;
    private GameObject[] lanes = new GameObject[12];
    
    private void Start()
    {
        var laneWidth = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height;
        var laneHeight = Camera.main.orthographicSize * 2.0 / 12;


        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = Instantiate(lanePrefab, new Vector3(transform.position.x, -Camera.main.orthographicSize + ((float)laneHeight * i) + ((float)laneHeight/2),  transform.position.z), Quaternion.identity);

            lanes[i].transform.localScale = new Vector3((float)laneWidth, (float)laneHeight, 0);

            RenderLane(lanes[i]);
        }
    }
    private void RenderLane(GameObject lane)
    {
        //lane.GetComponent<SpriteRenderer>().sprite = laneSprites[lane.GetComponent<Lane>().LaneType]
    }
}
