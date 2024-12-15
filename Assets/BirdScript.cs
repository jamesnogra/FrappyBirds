using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        flapStrength = 15;
        birdIsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPointerOverUI() && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            if (birdIsAlive)
            {
                myRigidBody.linearVelocityY = 1f * flapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private bool IsPointerOverUI()
    {
        // For mouse and touch input
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        // For touch input (required for mobile devices)
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return true;
        }

        return false;
    }
}
