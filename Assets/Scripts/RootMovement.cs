using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMovement : MonoBehaviour
{
    float horizInput;
    float vertInput;
    //[SerializeField] Camera mainCam;
    [SerializeField] float poopThreshold = 1f;
    [SerializeField] GameObject poop;
    [SerializeField] LineRenderer lRenderer;

    [SerializeField] float baseVelocity = 3f;
    [SerializeField] float maxVelocity = 6f;
    [SerializeField] float speedUpTime = 3f;

    [SerializeField] GameObject rootParent;

    float targetAngle = 0;

    float poopTime = 0f;

    Vector3 oldPosition;

    float currentSpeedTime = 0f;

    int nodeParentNum = 0;
    GameObject currentNodeParent;

    List<GameObject> nodes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        oldPosition = gameObject.transform.position;
        lRenderer.SetPosition(0, gameObject.transform.position);

        currentNodeParent = new GameObject();
        currentNodeParent.name = "Nodes0";
        currentNodeParent.transform.parent = rootParent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (nodes.Count == 0)
            lRenderer.SetPosition(1, gameObject.transform.position);

        else
            lRenderer.SetPosition(nodes.Count, gameObject.transform.position);

        poopTime += Time.deltaTime;

        if (poopTime >= poopThreshold * (Mathf.Pow(baseVelocity / gameObject.GetComponent<Rigidbody2D>().velocity.magnitude, 0.7f)))
        {
            nodes.Add(Instantiate(poop, oldPosition, Quaternion.identity));
            nodes[nodes.Count - 1].transform.parent = rootParent.transform;
            nodes[nodes.Count - 1].transform.parent = currentNodeParent.transform;

            poopTime = 0f;

            oldPosition = gameObject.transform.position;

            DrawNodeConnection();

            if (nodes.Count % 50 == 0)
            {
                nodeParentNum++;

                GameObject nodesParent = new GameObject();

                nodesParent.name = "Nodes" + nodeParentNum;
                nodesParent.transform.parent = rootParent.transform;

                currentNodeParent = nodesParent;

                if (nodeParentNum >= 2)
                {
                    GameObject.Find("Nodes" + (nodeParentNum - 2)).SetActive(false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        HandleInput();
        MoveRoot();
    }

    void HandleInput()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
    }

    void MoveRoot()
    {
        targetAngle += horizInput * -3;

        gameObject.GetComponent<Rigidbody2D>().SetRotation(targetAngle);

        //gameObject.GetComponent<Rigidbody2D>().velocity = -3 * gameObject.transform.up;

        if (vertInput >= 1)
        {
            if (currentSpeedTime < speedUpTime)
                currentSpeedTime += Time.fixedDeltaTime;

            else
                currentSpeedTime = speedUpTime;
        }

        else if (currentSpeedTime > 0f)
        {
            currentSpeedTime -= 2 * Time.fixedDeltaTime;

            if (currentSpeedTime < 0)
                currentSpeedTime = 0f;
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = -Mathf.Lerp(baseVelocity, maxVelocity, currentSpeedTime / speedUpTime) * gameObject.transform.up;

        //mainCam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCam.gameObject.transform.position.z);

        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
    }

    void DrawNodeConnection()
    {
        lRenderer.positionCount = nodes.Count + 1;

        lRenderer.SetPosition(nodes.Count - 1, nodes[nodes.Count - 1].transform.position);

        lRenderer.SetPosition(nodes.Count, gameObject.transform.position);

        if (nodes.Count >= 2)
        {
            nodes[nodes.Count - 2].AddComponent<CircleCollider2D>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("White Woman Detected!");
        }
    }
}
