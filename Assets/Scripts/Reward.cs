using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] private float move_speed_ = 2f; // Speed of the reward movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For each unit time, it move up
        transform.position += new Vector3(0, move_speed_ * Time.deltaTime, 0);
        if (transform.position.y >= 10f) // If the reward has moved up by 10 units
        {
            // Destroy the reward object
            Destroy(gameObject); // Destroy the reward object
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // If the player collides with the reward
        {
            // Destroy the reward object
            Destroy(gameObject); // Destroy the reward object
        }
    }
}
