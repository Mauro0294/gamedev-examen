using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    private float horizontalInput;
    private float timer = 0f;
    private float increaseSpeedInterval = 10f;
    private float speedIncreaseAmount = 2f;
    public int health = 5; 

    void FixedUpdate()
    {
        UpdateSpeed();
        
        // Move the vehicle forward constantly
        Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;

        // Use the horizontal input to move the vehicle left and right
        Vector3 moveHorizontal = transform.right * horizontalInput * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveForward + moveHorizontal);
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
