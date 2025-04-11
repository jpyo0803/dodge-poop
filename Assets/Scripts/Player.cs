using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float move_speed_= 5f; // Speed of the player movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Call the method to update the player's position
        UpdatePosition();
    }

    void UpdatePosition()
    {
        // Get the raw input from the user (immediate, no smoothing)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create a new vector for the movement direction
        Vector3 direction = new Vector3(horizontal, vertical, 0);

        // Normalize to prevent faster diagonal movement
        if (direction.magnitude > 1f)
            direction.Normalize();

        // Move the player in the direction of the input
        Vector3 pos_delta = direction * move_speed_ * Time.deltaTime;
        if (transform.position.y + pos_delta.y < -4.5f || transform.position.y + pos_delta.y > 4.5f) // If the player is out of bounds on the top
        {
            pos_delta.y = 0; // Set the vertical movement to 0
        }
        transform.position += pos_delta; // Update the player's position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with: " + other.name); // Log the name of the object collided with
        
        if (other.CompareTag("Reward")) // If the player collides with a reward
        {
            Reward reward = other.GetComponent<Reward>(); // Get the Reward component from the collided object
            GameManager.instance.UpdateScore(reward.GetScore()); // Update the score in the GameManager
            Destroy(other.gameObject); // Destroy the reward object
            Debug.Log("Reward collected!"); // Log the collection of the reward
        }
    }
}
