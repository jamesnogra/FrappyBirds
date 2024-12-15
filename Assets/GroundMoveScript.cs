using UnityEngine;

public class GroundMoveScript : MonoBehaviour
{
    public float moveSpeed;
    private float deadZone;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = 5;
        deadZone = -65;
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
