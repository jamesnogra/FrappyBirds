using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private float deadZone;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        deadZone = -45;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * logic.moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
