using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    int damage = 0;

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScore;

    float score;
    int roundedScore;

    float horizontalInput;
    float timer = 0f;
    float increaseSpeedInterval = 5f;
    float speedIncreaseAmount = 2f;

    float minX = -5.5f;
    float maxX = 3f;

    public GameObject restartObject;

    void FixedUpdate()
    {
        UpdateSpeed();

        // Move the vehicle forward constantly
        if (rb != null)
        {
            Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;

            // Use the horizontal input to move the vehicle left and right
            Vector3 moveHorizontal = transform.right * horizontalInput * speed * Time.fixedDeltaTime;

            Vector3 newPosition = rb.position + moveForward + moveHorizontal;

            // Clamp the new position within the allowed range
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            rb.MovePosition(newPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle left and right based on keyboard input
        horizontalInput = Input.GetAxis("Horizontal");

        updateUI();
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            damage += 20;
            if (damage >= 100) {
                Destroy(gameObject);
                restartObject.SetActive(true);
                gameOverScore.text = "Score: " + roundedScore.ToString();

                damageText.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(false);
            } else {
                Destroy(other.gameObject);
            }
        }
    }

    void updateUI()
    {
        score += Time.deltaTime * 15;

        if (scoreText != null)
        {
            roundedScore = Mathf.RoundToInt(score);
            scoreText.text = "Score: " + roundedScore.ToString();
        }

        if (damageText != null)
        {
            damageText.text = "Damage: " + damage + "%";
        }
        
    }
}
