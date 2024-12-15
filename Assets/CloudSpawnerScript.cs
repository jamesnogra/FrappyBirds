using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate, spawnRateLowerRange = 3f, spawnRateHigherRange = 7f;
    private float timer;
    public float heightOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCloud();
        spawnRate = 2;
        timer = 0;
        heightOffset = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            timer = 0;
            // Change spawn rate every time
            spawnRate = Random.Range(spawnRateLowerRange, spawnRateHigherRange);
        }
    }

    private void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(
            cloud,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), -3),
            transform.rotation
        );
    }
}
