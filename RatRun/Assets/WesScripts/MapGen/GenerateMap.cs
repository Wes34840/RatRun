using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Sprite[] laneSprites;
    [SerializeField] private GameObject lanePrefab;
    private GameObject[] lanes = new GameObject[13];

    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        var screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height / 16;
        var screenHeight = Camera.main.orthographicSize * 2;
        var laneHeight = screenHeight / lanes.Length;

        LaneType[] mapLayout = new LaneType[]
        {
                LaneType.Grass,
                LaneType.Road,
                LaneType.Road,
                LaneType.Road,
                LaneType.Road,
                LaneType.Road,
                LaneType.Grass,
                LaneType.Water,
                LaneType.Water,
                LaneType.Water,
                LaneType.Water,
                LaneType.Grass,
                LaneType.TopBar
        }; //bandaid fix because busy with fixing sprites

        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = Instantiate(lanePrefab, new Vector3(transform.position.x, -Camera.main.orthographicSize + (laneHeight * i) + (laneHeight / 2),  transform.position.z), Quaternion.identity);

            lanes[i].GetComponent<Lane>().type = mapLayout[i];

            lanes[i].transform.localScale = new Vector3(screenWidth, laneHeight, 0);

            RenderLane(lanes[i]);

            float direction;

            direction = Random.Range(0, 2) * 2 - 1;

            if (i >= 8)
            {
                direction = lanes[i - 1].GetComponent<Lane>().dirValue * -1;
                Debug.Log(direction);
            }

            lanes[i].GetComponent<SpawnScript>().InitSpawns(direction);
            lanes[i].GetComponent<Lane>().dirValue = direction;
        }

        Instantiate(playerPrefab, new Vector3(0, -Camera.main.orthographicSize + (laneHeight / 2), 0), Quaternion.identity);
    }
    private void RenderLane(GameObject lane)
    {
        SpriteRenderer render = lane.GetComponent<SpriteRenderer>();
        render.sprite = laneSprites[(int)lane.GetComponent<Lane>().type];
        if (lane.GetComponent<Lane>().type == LaneType.TopBar)
        {
            render.sortingOrder = 5; 
        }
    }
}
