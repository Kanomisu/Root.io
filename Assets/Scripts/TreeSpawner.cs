using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public static TreeSpawner instance;

    [SerializeField] GameObject treeBase;
    [SerializeField] GameObject treeMiddle;
    [SerializeField] GameObject treeTop;
    [SerializeField] GameObject rootOrigin;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnTree()
    {
        int score = ScoreManager.instance.score;

        int numPieces = (int)Mathf.Floor((float)score / (float)ScoreManager.instance.milestoneScore);

        GameObject lastPiece;

        lastPiece = Instantiate(treeBase, rootOrigin.transform.position + new Vector3(0f, 0f, -2f), Quaternion.identity);

        if (numPieces >= 1)
        {
            numPieces -= 1;

            lastPiece =  Instantiate(treeMiddle, lastPiece.transform.position + 
                new Vector3(0f, lastPiece.GetComponent<SpriteRenderer>().bounds.size.y / 2f + treeMiddle.GetComponent<SpriteRenderer>().bounds.size.y / 2f, 0f), 
                Quaternion.identity);
        }

        while (numPieces > 0)
        {
            numPieces--;

            lastPiece = Instantiate(treeMiddle, lastPiece.transform.position + new Vector3(0f, treeMiddle.GetComponent<SpriteRenderer>().bounds.size.y, 0f), Quaternion.identity);

            Debug.Log(treeMiddle.transform.localScale.y);

        }

        lastPiece = Instantiate(treeTop, lastPiece.transform.position + 
            new Vector3(0f, lastPiece.GetComponent<SpriteRenderer>().bounds.size.y / 2f + treeTop.GetComponent<SpriteRenderer>().bounds.size.y / 2f, 0f), 
            Quaternion.identity);

        Debug.Log("Final Score:" + ScoreManager.instance.score);

        return lastPiece;
    }
}
