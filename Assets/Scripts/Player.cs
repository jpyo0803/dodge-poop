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
        transform.position += direction * move_speed_ * Time.deltaTime;
    }
}
