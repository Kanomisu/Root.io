using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPocket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Slurp");
            WaterUI.instance.WaterAddition(2);
            ScoreManager.instance.AddScore(100);
        }
    }
}
