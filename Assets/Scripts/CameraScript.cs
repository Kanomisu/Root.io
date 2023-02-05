using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript instance;
    [SerializeField] GameObject player;
    [SerializeField] GameObject objectParent;
    float bottomBound = -3f;
    float speedFactor = 1f;
    float timer = 0f;
    Vector3 endPos;
    bool endGame = false;

    private void Awake()
    {
        instance = this;
    }

    public void speedUp(float added)
    {
        speedFactor += added;
    }

    private void FixedUpdate()
    {
        if (WaterUI.instance.GetWaterLevel() > 0)
        {

            if (player.transform.position.y <= gameObject.transform.position.y + bottomBound)
            {
                //Debug.Log("player is below bottom bound");
                gameObject.transform.position -= Vector3.down * speedFactor * (2 + player.transform.position.y - gameObject.transform.position.y + bottomBound) * Time.fixedDeltaTime;
            }
            else
            {
                //Debug.Log("player is between ceiling and bottom bound");
                gameObject.transform.position += Vector3.down * speedFactor * Time.fixedDeltaTime;
            }
        }
        else
        {
            endGame = true;
            endPos = transform.position;

            for (int i = 0; i < objectParent.transform.childCount; i++)
            {
                objectParent.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if (endGame)
        {
            timer += Time.fixedDeltaTime / 10;
            transform.position = Vector3.Lerp(endPos, new Vector3(0f, 8f, -10), timer);
        }
    }
}
