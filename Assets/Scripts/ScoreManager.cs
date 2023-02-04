using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    [SerializeField] GameObject player;
    private int depthMilestone = -20;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int added)
    {
        score += added;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y < depthMilestone)
        {
            AddScore(100);
            depthMilestone -= 20;
            Debug.Log("Depth Milestone passed, 100 points");
        }
    }
}
