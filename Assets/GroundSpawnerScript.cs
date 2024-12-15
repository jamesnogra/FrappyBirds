using UnityEngine;

public class GroundSpawnerScript : MonoBehaviour
{
    public GameObject ground;
    public float spawnRate;
    private float timer;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnGround();
        spawnRate = 15;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float updatedSpawnRate = spawnRate - logic.moveSpeed;
        if (updatedSpawnRate < 1)
        {
            updatedSpawnRate = 0.5f;
        }
        if (timer < updatedSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnGround();
            timer = 0;
        }
    }

    private void spawnGround()
    {
        Instantiate(
            ground,
            new Vector3(transform.position.x, transform.position.y, -5),
            transform.rotation
        );
    }
}
