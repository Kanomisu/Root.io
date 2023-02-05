using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthMeterScript : MonoBehaviour
{
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float depthLevel = (ScoreManager.instance.depthMilestone) / -60;
        Vector2 newPosition = Vector2.Lerp(startPos, endPos, depthLevel / 10);
        gameObject.GetComponent<RectTransform>().anchoredPosition = newPosition;
    }
}
