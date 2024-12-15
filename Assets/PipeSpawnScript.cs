using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate, spawnRateLowerRange = 3f, spawnRateHigherRange = 7f;
    private float timer;
    public float heightOffset;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPipe();
        spawnRate = 3; // Initial spawn rate of pipe is 3
        timer = 0;
        heightOffset = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float updatedSpanRate = spawnRate - (logic.playerScore / logic.scoreDivisor);
        if (updatedSpanRate < 1) // Limit minimum spawn rate
        {
            updatedSpanRate = 1;
        }
        if (timer < updatedSpanRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
            // Change spawn rate every time
            spawnRate = Random.Range(spawnRateLowerRange, spawnRateHigherRange);
        }
    }

    private void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(
            pipe,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );
    }
}
