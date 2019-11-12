using UnityEngine;

public class Piranha : MonoBehaviour
{
    [SerializeField]
    float positionOffset = 1;
    [SerializeField]
    public int boundaryMax = 2;
    [SerializeField]
    public float moveSpeed = 1;

    int boundaryCounter;
    Transform leftBoundary;
    Transform rightBoundary;
    GameSpawner gameSpawnerVariable;

    void Start()
    {
        boundaryCounter = 0;
        leftBoundary = GameObject.Find("LeftBoundary").transform;
        rightBoundary = GameObject.Find("RightBoundary").transform;
        gameSpawnerVariable = GameObject.Find("GameSpawner").GetComponent<GameSpawner>();
    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().alive)
        {
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            }
        }

        if (transform.position.x > rightBoundary.position.x - positionOffset - 1)
        {
            transform.position = new Vector2(leftBoundary.position.x + positionOffset, transform.position.y);
            boundaryCounter += 1;
        }
        if (transform.position.x < leftBoundary.position.x + positionOffset)
        {
            transform.position = new Vector2(rightBoundary.position.x - positionOffset - 1, transform.position.y);
            boundaryCounter += 1;
        }

        if (boundaryCounter == boundaryMax)
        {
            gameSpawnerVariable.piranhaYList.Add((int)(transform.position.y));
            gameSpawnerVariable.piranhaCounter -= 1;
            Destroy(gameObject);
        }

    }
}
