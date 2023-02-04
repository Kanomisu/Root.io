using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] float spawnDifferenceMin = 5f;
    [SerializeField] float spawnDifferenceMax = 10f;

    [SerializeField] List<GameObject> obstacles;
    [SerializeField] GameObject wallObj;

    [SerializeField] Camera mainCam;

    [Header("Obstcale Generation Properties")]
    [SerializeField] float worldWidth = 60f;
    [SerializeField] int divisions = 6;
    [SerializeField] int minColumnSpawns = 2;
    [SerializeField] int maxColumnSpawns = 10;

    int layer = -1;
    float layerHeight;

    // Start is called before the first frame update
    void Start()
    {
        layerHeight = wallObj.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.transform.position.y <= -layerHeight * layer)
        {
            layer++;
            Instantiate(wallObj, new Vector3(-30f, -layer * layerHeight, 0f), Quaternion.identity);
            Instantiate(wallObj, new Vector3(30f, -layer * layerHeight, 0f), Quaternion.identity);

            for (int i = 0; i < divisions; i++)
            {
                int numInColumn = Random.Range(minColumnSpawns, maxColumnSpawns);

                float rangePerObject = layerHeight / (float)numInColumn;

                for (int j = 0; j < numInColumn; j++)
                {
                    Vector3 spawnLoc = new Vector3(Random.Range((worldWidth / divisions) * i, (worldWidth / divisions) * (i + 1)) - worldWidth / 2f, 
                        Random.Range(rangePerObject * j, rangePerObject * (j + 1)) - ((layer + 0.5f) * layerHeight), 
                        0f);

                    int obstacleSpawned = Random.Range(0, obstacles.Count);

                    Instantiate(obstacles[obstacleSpawned], spawnLoc, Quaternion.identity);
                }
            }
        }


    }
}
