using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    [SerializeField] GameObject player;
    public int depthMilestone = -60;
    public int depthLevel = 0;
    public int milestoneNum = 60;
    public int milestoneScore = 100;

    private void Awake()
    {
        instance = this;

        milestoneNum = -depthMilestone;
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
            AddScore(milestoneScore);
            depthMilestone -= milestoneNum;
            depthLevel++;
            CameraScript.instance.speedUp(0.3f);
            Debug.Log("Depth Milestone passed, 100 points");
        }
    }
}
