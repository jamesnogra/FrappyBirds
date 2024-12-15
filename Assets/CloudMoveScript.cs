using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float moveSpeed, cloudScale;
    private float deadZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloudScale = Random.Range(0.4f, 1.5f);
        moveSpeed = 5 * cloudScale;
        deadZone = -45;
    }

    // Update is called once per frame
    void Update()
    {
        int moveSpeedToAdd = 1;
        float updatedMoveSpeed = moveSpeed + moveSpeedToAdd;
        transform.localScale = new Vector3(cloudScale, cloudScale, 1.0f);
        transform.position = transform.position + (Vector3.left * updatedMoveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
