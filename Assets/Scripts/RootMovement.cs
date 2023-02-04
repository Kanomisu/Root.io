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
    [SerializeField] LineRenderer lRenderer;

    float targetAngle = 0;

    float poopTime = 0f;

    Vector3 oldPosition;

    List<GameObject> nodes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");

        targetAngle += horizInput * -3;

        gameObject.GetComponent<Rigidbody2D>().SetRotation(targetAngle);

        gameObject.GetComponent<Rigidbody2D>().velocity = -3 * gameObject.transform.up;

        mainCam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCam.gameObject.transform.position.z);

        poopTime += Time.deltaTime;

        if (poopTime >= poopThreshold)
        {
            nodes.Add(Instantiate(poop, oldPosition, Quaternion.identity));

            poopTime = 0f;

            oldPosition = gameObject.transform.position;

            DrawNodeConnection();
        }
    }

    void DrawNodeConnection()
    {
        lRenderer.positionCount = nodes.Count;

        lRenderer.SetPosition(nodes.Count - 1, nodes[nodes.Count - 1].transform.position);

        /*
        if (nodes.Count >= 2)
        {
            
        }
        */
    }
}
