using System;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    private float deadZone;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = 5;
        deadZone = -45;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase speed for every point
        float moveSpeedToAdd = logic.playerScore / logic.scoreDivisor;
        float updatedMoveSpeed = moveSpeed + moveSpeedToAdd;
        transform.position = transform.position + (Vector3.left * updatedMoveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
