using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Sprite[] laneSprites;
    [SerializeField] private GameObject lanePrefab;
    private GameObject[] lanes = new GameObject[12];
    
    private void Start()
    {
        var screenWidth = Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height / 19.2;
        var screenHeight = Camera.main.orthographicSize * 2.0;
        var laneHeight = screenHeight / 12;

        LaneType[] mapLayout = new LaneType[]
        {
                LaneType.Grass,
                LaneType.Road,
                LaneType.Road,
                LaneType.Road,
                LaneType.Road,
                LaneType.Grass,
                LaneType.Water,
                LaneType.Water,
                LaneType.Water,
                LaneType.Water,
                LaneType.Grass
        }; //bandaid fix because busy with fixing sprites

        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = Instantiate(lanePrefab, new Vector3(transform.position.x, -Camera.main.orthographicSize + ((float)laneHeight * i) + ((float)laneHeight / 2),  transform.position.z), Quaternion.identity);

            lanes[i].GetComponent<Lane>().type = mapLayout[i];

            lanes[i].transform.localScale = new Vector3((float)screenWidth, (float)laneHeight, 0);

            RenderLane(lanes[i]);

            lanes[i].transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 1.2f, 0);
        }
    }
    private void RenderLane(GameObject lane)
    {
        SpriteRenderer render = lane.GetComponent<SpriteRenderer>();
        render.sprite = laneSprites[(int)lane.GetComponent<Lane>().type];
    }
}
