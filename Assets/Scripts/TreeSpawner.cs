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

        lastPiece = Instantiate(treeBase, rootOrigin.transform.position + new Vector3(0f, treeBase.transform.localScale.y / 2f, -2f), Quaternion.identity);

        if (numPieces >= 1)
        {
            numPieces -= 1;

            lastPiece =  Instantiate(treeMiddle, lastPiece.transform.position + new Vector3(0f, 
                                lastPiece.transform.localScale.y / 2f + treeMiddle.transform.localScale.y / 2f, 0f), 
                                Quaternion.identity);
        }

        while (numPieces > 0)
        {
            numPieces--;

            lastPiece = Instantiate(treeMiddle, lastPiece.transform.position + new Vector3(0f, treeMiddle.transform.localScale.y, 0f), Quaternion.identity);

        }

        lastPiece = Instantiate(treeTop, lastPiece.transform.position + 
            new Vector3(0f, treeMiddle.transform.localScale.y / 2f + treeTop.transform.localScale.y / 2f, -2f), 
            Quaternion.identity);

        return lastPiece;
    }
}
