using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] List<int> spawnChances = new List<int>();
    [SerializeField] GameObject wallObj;
    [SerializeField] GameObject dirtTile;  

    [SerializeField] Camera mainCam;

    [Header("Obstcale Generation Properties")]
    [SerializeField] float worldWidth = 60f;
    [SerializeField] int divisions = 6;
    [SerializeField] int minColumnSpawns = 2;
    [SerializeField] int maxColumnSpawns = 10;
    [SerializeField] GameObject obstacleParent;

    int layer = -1;
    float layerHeight;

    int totalChance = 0;

    // Start is called before the first frame update
    void Start()
    {
        layerHeight = wallObj.transform.localScale.y * wallObj.GetComponent<SpriteRenderer>().size.y;

        for (int i = 0; i < spawnChances.Count; i++)
        {
            totalChance += spawnChances[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.transform.position.y <= -layerHeight * layer)
        {
            layer++;

            GameObject parentEmpty = new GameObject(); 
            parentEmpty.name = "Layer" + layer;

            Instantiate(wallObj, new Vector3(-worldWidth / 2 - (wallObj.transform.localScale.x * wallObj.GetComponent<SpriteRenderer>().size.x) / 2f, 
                -layer * layerHeight, 3f), 
                Quaternion.identity)
                .transform.parent = parentEmpty.transform;

            Instantiate(wallObj, new Vector3(worldWidth / 2 + (wallObj.transform.localScale.x * wallObj.GetComponent<SpriteRenderer>().size.x) / 2f, 
                -layer * layerHeight, 3f), 
                Quaternion.identity)
                .transform.parent = parentEmpty.transform;

            GameObject newDirt = Instantiate(dirtTile, new Vector3(0f, -layer * layerHeight, 5f), Quaternion.identity);
            newDirt.GetComponent<SpriteRenderer>().size = new Vector2(worldWidth, layerHeight);
            newDirt.transform.parent = parentEmpty.transform;

            for (int i = 0; i < divisions; i++)
            {
                int numInColumn = Random.Range(minColumnSpawns, maxColumnSpawns);

                float rangePerObject = layerHeight / (float)numInColumn;

                for (int j = 0; j < numInColumn; j++)
                {
                    Vector3 spawnLoc = new Vector3(Random.Range((worldWidth / divisions) * i, (worldWidth / divisions) * (i + 1)) - worldWidth / 2f, 
                        Random.Range(rangePerObject * j, rangePerObject * (j + 1)) - ((layer + 0.5f) * layerHeight), 
                        0f);

                    int obstacleSpawned = Random.Range(0, totalChance);
                    int currentTotal = 0;

                    for (int k = 0; k <= spawnChances.Count; k++)
                    {
                        currentTotal += spawnChances[k];

                        if (currentTotal >= obstacleSpawned)
                        {
                            obstacleSpawned = k;
                            break;
                        }
                    }

                    Vector3 eulers;

                    if (obstacles[obstacleSpawned].CompareTag("Water"))
                        eulers = new Vector3(0f, 0f, 0f);

                    else
                        eulers = new Vector3(0f, 0f, Random.Range(0f, 360f));

                    Instantiate(obstacles[obstacleSpawned], spawnLoc, Quaternion.Euler(eulers)).transform.parent = parentEmpty.transform;
                }
            }

            parentEmpty.transform.parent = obstacleParent.transform;

            if (layer >= 2)
            {
                GameObject.Find("Layer" + (layer - 2)).SetActive(false);
            }
        }
    }
}
