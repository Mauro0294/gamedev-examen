using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public int health = 5;
    float horizontalInput;
    float timer = 0f;
    float increaseSpeedInterval = 5f;
    float speedIncreaseAmount = 2f;
    float minX = -5.5f;
    float maxX = 3f;

    void FixedUpdate()
    {
        UpdateSpeed();

        // Move the vehicle forward constantly
        Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;

        // Use the horizontal input to move the vehicle left and right
        Vector3 moveHorizontal = transform.right * horizontalInput * speed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + moveForward + moveHorizontal;

        // Clamp the new position within the allowed range
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        rb.MovePosition(newPosition);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle left and right based on keyboard input
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void UpdateSpeed()
    {
        timer += Time.deltaTime;
        if (timer >= increaseSpeedInterval)
        {
            timer = 0f;
            speed += speedIncreaseAmount;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            health--;
            if (health <= 0) {
                Destroy(gameObject);
            } else {
                Destroy(other.gameObject);
            }
        }
    }
}
