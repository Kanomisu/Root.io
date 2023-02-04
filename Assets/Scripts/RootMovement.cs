using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMovement : MonoBehaviour
{
    float horizInput;
    float vertInput;
    [SerializeField] Camera mainCam;
    [SerializeField] float poopThreshold = 1f;
    [SerializeField] GameObject poop;

    float poopTime = 0f;

    Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");

        gameObject.transform.Rotate(new Vector3(0f, 0f, 0.5f * horizInput));

        gameObject.GetComponent<Rigidbody2D>().velocity = -3 * gameObject.transform.up;

        mainCam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCam.gameObject.transform.position.z);

        poopTime += Time.deltaTime;

        if (poopTime >= poopThreshold)
        {
            Instantiate(poop, oldPosition, Quaternion.identity);

            poopTime = 0f;

            oldPosition = gameObject.transform.position;
        }

    }


}
