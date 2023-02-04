using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    float bottomBound = -3f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (player.transform.position.y <= gameObject.transform.position.y + bottomBound)
        {
            Debug.Log("player is below bottom bound");
            //gameObject.transform.position -= Vector3.down * Time.deltaTime * (player.transform.position.y - gameObject.transform.position.y + bottomBound);
            gameObject.transform.position -= Vector3.down * (2 + player.transform.position.y - gameObject.transform.position.y + bottomBound) * Time.deltaTime;

        }
        else if (player.transform.position.y > gameObject.transform.position.y)
        {
            Debug.Log("player is above camera center");
            gameObject.transform.position += Vector3.down * Time.deltaTime;
        }
        else
        {
            Debug.Log("player is between ceiling and bottom bound");
            gameObject.transform.position += Vector3.down * Time.deltaTime;
        }
        */
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y <= gameObject.transform.position.y + bottomBound)
        {
            Debug.Log("player is below bottom bound");
            gameObject.transform.position -= Vector3.down * (2 + player.transform.position.y - gameObject.transform.position.y + bottomBound) * Time.fixedDeltaTime;
        }
        else
        {
            Debug.Log("player is between ceiling and bottom bound");
            gameObject.transform.position += Vector3.down * Time.fixedDeltaTime;
        }

    }
}
